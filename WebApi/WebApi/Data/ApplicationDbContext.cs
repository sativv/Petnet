using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<InterestModel> Interests { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ApplicationUser configurations
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.ApplicationUser)
                .HasForeignKey(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Interests)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.ReviewsWritten)
                .WithOne(r => r.Reviewer)
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.ReviewsRecieved)
                .WithOne(r => r.ReviewedSeller)
                .HasForeignKey(r => r.ReviewedSellerId)
                .OnDelete(DeleteBehavior.NoAction);

            // InterestModel configurations
            modelBuilder.Entity<InterestModel>()
                .HasOne(i => i.User)
                .WithMany(u => u.Interests)
                .HasForeignKey(i => i.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<InterestModel>()
                .HasOne(i => i.PostModel)
                .WithMany()
                .HasForeignKey(i => i.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            // PostModel configurations
            modelBuilder.Entity<PostModel>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);

            // ReviewModel configurations
            modelBuilder.Entity<ReviewModel>()
                .HasOne(r => r.Reviewer)
                .WithMany(u => u.ReviewsWritten)
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ReviewModel>()
                .HasOne(r => r.ReviewedSeller)
                .WithMany(u => u.ReviewsRecieved)
                .HasForeignKey(r => r.ReviewedSellerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure composite key for InterestModel
            modelBuilder.Entity<InterestModel>()
                .HasKey(i => new { i.ApplicationUserId, i.PostId });

            // Configure primary key for ReviewModel
            modelBuilder.Entity<ReviewModel>()
                .HasKey(r => r.ReviewId);
        }
    }
}
