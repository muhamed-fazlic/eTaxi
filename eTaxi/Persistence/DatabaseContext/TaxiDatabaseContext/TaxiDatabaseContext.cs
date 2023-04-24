using eTaxi.Domain;
using eTaxi.Domain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext
{
    public class TaxiDatabaseContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public TaxiDatabaseContext(DbContextOptions<TaxiDatabaseContext> options) : base(options)
        {

        }

        public DbSet<User> ApplicationUser { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Favorite> Favorite { get; set; }

        public DbSet<Rating> Rating { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Seed.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //Added automatically time updater (DateCreated, DateModified)
            var users = base.ChangeTracker.Entries<User>()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            var entites = base.ChangeTracker.Entries<BaseEntity>()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var item in users)
            {
                item.Entity.DateModified = DateTime.Now;

                if (item.State == EntityState.Added)
                    item.Entity.DateCreated = DateTime.Now;
            }

            foreach (var item in entites)
            {
                item.Entity.DateModified = DateTime.Now;

                if (item.State == EntityState.Added)
                    item.Entity.DateCreated = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
