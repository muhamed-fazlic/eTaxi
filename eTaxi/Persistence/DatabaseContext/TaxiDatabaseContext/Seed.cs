using eTaxi.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext
{
    public static class Seed
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 2, Name = "User", NormalizedName = "USER" });
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 3, Name = "CompanyAdmin", NormalizedName = "COMPANYADMIN" });


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "admin",
                FirstName = "Admin",
                LastName = "eTaxi",
                NormalizedUserName = "ADMIN".ToUpper(),
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "test12345"),
                SecurityStamp = string.Empty,
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                UserName = "fazla",
                FirstName="Muhamed",
                LastName="Fazlic",
                NormalizedUserName = "FAZLA".ToUpper(),
                Email = "fazla@admin.com",
                NormalizedEmail = "FAZLA@ADMIN.COM".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "test12345"),
                SecurityStamp = string.Empty,
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                UserName = "billy",
                FirstName = "Bilal",
                LastName = "Hodzic",
                NormalizedUserName = "BILLY".ToUpper(),
                Email = "billy@admin.com",
                NormalizedEmail = "BILLY@ADMIN.COM".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "test12345"),
                SecurityStamp = string.Empty,
            });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 1, RoleId = 1 });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 2, RoleId = 2 });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 3, RoleId = 2 });

            modelBuilder.Entity<VehicleType>().HasData(new VehicleType {
                Id= 1,
                Type="malo auto",
                NumberOfSeats= 4,
               ImageUrl= "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/car_l5aypi.png"
            });
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType
            {
                Id = 2,
                Type = "limuzina",
                NumberOfSeats = 5,
                ImageUrl = "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/sedan_j0oo9s.png"
            });
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType
            {
                Id = 3,
                Type = "SUV",
                NumberOfSeats = 5,
                ImageUrl = "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/SUV_hjqwbi.png"
            });
        }
    }
}
