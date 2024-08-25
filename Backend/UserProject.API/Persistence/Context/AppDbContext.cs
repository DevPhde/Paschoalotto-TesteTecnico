using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UserProject.API.Entities;

namespace UserProject.API.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(u => u.Login)
                .WithOne(l => l.User)
                .HasForeignKey<Login>(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(u => u.Location)
                .WithOne(l => l.User)
                .HasForeignKey<Location>(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(u => u.Picture)
                     .WithOne(p => p.User)
                     .HasForeignKey<Picture>(p => p.UserId)
                     .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Login>(entity => { entity.HasKey(x => x.Id); });
            modelBuilder.Entity<Location>(entity => { entity.HasKey(x => x.Id); });
            modelBuilder.Entity<Picture>(entity => { entity.HasKey(x => x.Id); });


            base.OnModelCreating(modelBuilder);
        }
    }
}
