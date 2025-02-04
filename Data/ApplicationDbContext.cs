using Microsoft.EntityFrameworkCore;
using VideoRentalShopAPI.Models;


namespace VideoShopRentalAPIv3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RentalHeader> RentalHeaders { get; set; }
        public DbSet<RentalDetail> RentalDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentalHeader>()
                .HasOne(rh => rh.Customer)
                .WithMany(c => c.RentalHeaders)
                .HasForeignKey(rh => rh.CustomerId);

            modelBuilder.Entity<RentalDetail>()
                .HasOne(rd => rd.RentalHeaders)
                .WithMany(rh => rh.RentalDetails)
                .HasForeignKey(rd => rd.RentalHeaderId);

            modelBuilder.Entity<RentalDetail>()
               .HasOne(rd => rd.Movies)
               .WithMany(k => k.RentalDetails)
               .HasForeignKey(rd => rd.MovieId);

        }
    }

}
