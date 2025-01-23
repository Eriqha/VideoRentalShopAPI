using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Reflection.Metadata;
using System.Transactions;
using VideoRentalShopAPI.Models;

namespace VideoRentalShopAPI.Data
{
    public class VideoShopContext : DbContext
    {
        public VideoShopContext(DbContextOptions<VideoShopContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RentalHeader> RentalTransactions { get; set; }
        public DbSet<RentalDetail> RentalTransactionDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentalHeader>()
                .HasMany(rt => rt.RentalDetails)
                .WithOne(td => td.Transaction)
                .HasForeignKey(td => td.TransactionId);

            modelBuilder.Entity<RentalDetail>()
                .HasOne(td => td.Movie)
                .WithMany()
                .HasForeignKey(td => td.MovieId);
        }
    }


}

