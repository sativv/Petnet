using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<InterestModel> Interests { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Seed ApplicationUser
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "user1",
                    UserName = "user1@example.com",
                    Email = "user1@example.com",
                    IsPrivateSeller = true,
                    IsVerified = true
                },
                new ApplicationUser
                {
                    Id = "user2",
                    UserName = "user2@example.com",
                    Email = "user2@example.com",
                    IsPrivateSeller = false,
                    IsVerified = false
                }
            );

            // Seed PostModel
            modelBuilder.Entity<PostModel>().HasData(
                new PostModel
                {
                    Id = 1,
                    Title = "Post 1",
                    Description = "Description for post 1",
                    AnimalType = "Dog",
                    AnimalBreed = "Labrador",
                    Age = 2,
                    IsAdoptionReady = true,
                    EarliestDelivery = DateOnly.Parse("2024-09-01"),
                    ApplicationUserId = "user1" // FK to ApplicationUser
                },
                new PostModel
                {
                    Id = 2,
                    Title = "Post 2",
                    Description = "Description for post 2",
                    AnimalType = "Cat",
                    AnimalBreed = "Siamese",
                    Age = 1,
                    IsAdoptionReady = false,
                    EarliestDelivery = DateOnly.Parse("2024-10-01"),
                    ApplicationUserId = "user2" // FK to ApplicationUser
                }
            );

            // Seed InterestModel
            modelBuilder.Entity<InterestModel>().HasData(
                new InterestModel
                {
                    ApplicationUserId = "user1",
                    PostId = 1
                },
                new InterestModel
                {
                    ApplicationUserId = "user2",
                    PostId = 2
                }
            );

            // Seed ReviewModel
            modelBuilder.Entity<ReviewModel>().HasData(
                new ReviewModel
                {
                    ReviewId = 1,
                    Content = "Great post!",
                    Rating = 5,
                    ReviewerId = "user1",
                    ReviewedSellerId = "user2"
                },
                new ReviewModel
                {
                    ReviewId = 2,
                    Content = "Very helpful.",
                    Rating = 4,
                    ReviewerId = "user2",
                    ReviewedSellerId = "user1"
                }
            );

            // ApplicationUser to PostModel (1 to Many)
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.ApplicationUser)
                .HasForeignKey(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict); // Use Restrict instead of Cascade

            // Configure composite key for InterestModel
            modelBuilder.Entity<InterestModel>()
                .HasKey(i => new { i.ApplicationUserId, i.PostId });

            // ApplicationUser to InterestModel (1 to Many)
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Interests)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict); // Use Restrict instead of Cascade

            // ApplicationUser to PostModel (1 to Many)
            modelBuilder.Entity<PostModel>()
                .HasMany(p => p.Interests)
                .WithOne(i => i.PostModel)
                .HasForeignKey(i => i.PostId)
                .OnDelete(DeleteBehavior.Restrict); // Use Restrict instead of Cascade

            // ApplicationUser to ReviewModel (Written Reviews) (1 to Many)
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.ReviewsWritten)
                .WithOne(r => r.Reviewer)
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // ApplicationUser to ReviewModel (Received Reviews) (1 to Many)
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.ReviewsRecieved)
                .WithOne(r => r.ReviewedSeller)
                .HasForeignKey(r => r.ReviewedSellerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // ReviewModel configurations
            modelBuilder.Entity<ReviewModel>()
                .HasOne(r => r.Reviewer)
                .WithMany(u => u.ReviewsWritten)
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReviewModel>()
                .HasOne(r => r.ReviewedSeller)
                .WithMany(u => u.ReviewsRecieved)
                .HasForeignKey(r => r.ReviewedSellerId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
