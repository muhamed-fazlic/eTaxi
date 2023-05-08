using eTaxi.Application.Models.Identity;

namespace eTaxi.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<HttpResponseMessage> ForgotPassword(ForgotPasswordRequest request);
        Task<HttpResponseMessage> ResetPassword(ResetPassword request);
    }
}
