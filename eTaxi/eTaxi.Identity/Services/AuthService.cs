using eTaxi.Application.Contracts.Email;
using eTaxi.Application.Contracts.Identity;
using eTaxi.Application.Exceptions;
using eTaxi.Application.Models.Email;
using eTaxi.Application.Models.Identity;
using eTaxi.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eTaxi.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IEmailSender _emailSender;
        public AuthService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IOptions<JwtSettings> jwtSettings,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _emailSender = emailSender;
        }
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                throw new NotFoundException($"User with {request.Email} not found", request.Email);

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
            {
                throw new BadRequestException($"Credentials for '{request.Email}' aren't valid.");
            }

            JwtSecurityToken token = await GenerateToken(user);

            var response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName??"null"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email??"null"),
                new Claim("uid", user.Id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signinCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signinCredentials);

            return token;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var user = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
                throw new BadRequestException($"{result.Errors}");
        }

        public async Task<HttpResponseMessage> ForgotPassword(ForgotPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new NotFoundException($"User with {request.Email} not found", request.Email);

            Random rnd = new Random();
            int pin = rnd.Next(1000, 9999);
            user.Pin = pin;
            await _userManager.UpdateAsync(user);
            var htmlMessage = GenerateForgotPasswordMessage(pin.ToString());
            var message = new EmailMessage(new string[] { request.Email }, "Ponistavanje lozike", htmlMessage);
            await _emailSender.SendEmailAsync(message);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        private string GenerateForgotPasswordMessage(string pin)
        {
            StringBuilder email = new StringBuilder();
            email.Append("<div style=\"font-family: Bahnschrift Light;max-width: 500px;margin: 20px auto auto auto;overflow: hidden;\">");
            email.Append("<div style=\"padding: 10px 0; text-align: center; background-color: #2bdea8; \">");
            email.Append("</div>");
            email.Append("<div style=\"padding: 30px 40px\">");
            email.Append("<h2>Poštovani,</h2>");
            email.Append("<p>Zaboravili ste lozinku? Nema problema!</p>");
            email.Append($"<h3 style=\"text-align: center; margin: 30px 0\">{pin}</h3>");
            email.Append("<p>Pomoću ovog PIN-a možete resetirati svoju lozinku.</p>");
            email.Append("<p>Srdačan pozdrav.</p>");
            email.Append("</div>");
            email.Append("</div>");
            return email.ToString();
        }
        public async Task<HttpResponseMessage> ResetPassword(ResetPassword model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                throw new NotFoundException($"User with {model.Email} not found", model.Email);

            if (model.Password != model.ConfirmPassword)
                throw new BadRequestException("Lozinka se ne podudara");
            if (user.Pin == model.Pin)
            {
                var result = await _userManager.ResetPasswordAsync(user, await _userManager.GeneratePasswordResetTokenAsync(user), model.Password);
                if (user != null)
                {
                    if (result.Succeeded)
                    {
                        user.Pin = null;
                        await _userManager.UpdateAsync(user);
                        return new HttpResponseMessage(System.Net.HttpStatusCode.OK);

                    }
                    else
                    {
                        throw new BadRequestException("Pin za poništavanje je nevažeći ");
                    }
                }
                else
                {
                    throw new BadRequestException("Ne postoji račun s ovom e-poštom.");

                }
            }
            else
            {
                throw new BadRequestException("Pogrešan pin");
            }
        }

       
    }
}
