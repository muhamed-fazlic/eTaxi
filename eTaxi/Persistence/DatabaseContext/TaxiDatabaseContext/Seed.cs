using eTaxi.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DatabaseContext.TaxiDatabaseContext
{
    public static class Seed
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "admin",
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
                NormalizedUserName = "BILLY".ToUpper(),
                Email = "billy@admin.com",
                NormalizedEmail = "BILLY@ADMIN.COM".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "test12345"),
                SecurityStamp = string.Empty,
            });
        }
    }
}
