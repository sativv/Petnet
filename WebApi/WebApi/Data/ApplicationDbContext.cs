using Microsoft.AspNetCore.Identity;
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
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<QuizModel> Quiz { get; set; }
        public DbSet<OptionModel> Options { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        private void SeedUsers(ModelBuilder builder)
        {

            ApplicationUser user1 = new ApplicationUser
            {
                Id = "user1",
                UserName = "user1@example.com",
                Email = "user1@example.com",
                IsPrivateSeller = true,
                IsVerified = true
            };

            ApplicationUser user2 = new ApplicationUser
            {
                Id = "user2",
                UserName = "user2@example.com",
                Email = "user2@example.com",
                IsPrivateSeller = false,
                IsVerified = false
            };


            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            user1.PasswordHash = passwordHasher.HashPassword(user1, "user1*123");
            user2.PasswordHash = passwordHasher.HashPassword(user2, "user2*123");
            builder.Entity<ApplicationUser>().HasData(user1, user2);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<QuizModel>().HasData(
         new QuizModel
         {
             QuizId = 1,
             Title = "Vilket djur passar dig bäst?"
         }
          );

            modelBuilder.Entity<QuestionModel>().HasData(
        new QuestionModel { QuestionId = 1, QuizId = 1, Text = "Hur ser en perfekt helg ut för dig?" },
        new QuestionModel { QuestionId = 2, QuizId = 1, Text = "Vilken miljö trivs du bäst i?" },
        new QuestionModel { QuestionId = 3, QuizId = 1, Text = "Hur mycket tid vill du lägga på ditt husdjur?" },
        new QuestionModel { QuestionId = 4, QuizId = 1, Text = "Vad är din favorit typ av aktivitet?" },
        new QuestionModel { QuestionId = 5, QuizId = 1, Text = "Hur hanterar du stress?" },
        new QuestionModel { QuestionId = 6, QuizId = 1, Text = "Hur ser du på att ta hand om ett husdjur?" },
        new QuestionModel { QuestionId = 7, QuizId = 1, Text = "Hur viktigt är det för dig att ditt hem är organiserat?" },
        new QuestionModel { QuestionId = 8, QuizId = 1, Text = "Hur social är du?" },
        new QuestionModel { QuestionId = 9, QuizId = 1, Text = "Hur ser du på motion?" },
        new QuestionModel { QuestionId = 10, QuizId = 1, Text = "Hur viktig är rutinen i ditt liv?" },
        new QuestionModel { QuestionId = 11, QuizId = 1, Text = "Vilken typ av sällskap föredrar du?" },
        new QuestionModel { QuestionId = 12, QuizId = 1, Text = "Vad är din inställning till städning?" },
        new QuestionModel { QuestionId = 13, QuizId = 1, Text = "Hur reagerar du på ljud och aktiviteter i ditt hem?" },
        new QuestionModel { QuestionId = 14, QuizId = 1, Text = "Vad är din syn på husdjursansvar?" },
        new QuestionModel { QuestionId = 15, QuizId = 1, Text = "Vad tycker du om att ha besök hemma?" }
    );

            modelBuilder.Entity<OptionModel>().HasData(
    // Question 1 options
    new OptionModel { OptionId = 1, QuestionId = 1, Option = "Jag älskar att vara ute och vara aktiv", Animal = "Hund" },
    new OptionModel { OptionId = 2, QuestionId = 1, Option = "Ligga i soffan och mysa med en bra film", Animal = "Katt" },
    new OptionModel { OptionId = 3, QuestionId = 1, Option = "Läsa en bok eller pyssla i trädgården", Animal = "Kanin" },
    new OptionModel { OptionId = 4, QuestionId = 1, Option = "Organisera och dekorera hemmet", Animal = "Fågel" },
    new OptionModel { OptionId = 5, QuestionId = 1, Option = "Njuta av ett lugnt och stilla hem", Animal = "Akvarium" },
    new OptionModel { OptionId = 6, QuestionId = 1, Option = "Upptäcka nya intressen och hobbyer", Animal = "Reptil" },

    // Question 2 options
    new OptionModel { OptionId = 7, QuestionId = 2, Option = "Ute i naturen, kanske i en park eller skog", Animal = "Hund" },
    new OptionModel { OptionId = 8, QuestionId = 2, Option = "Inomhus, där jag kan ta det lugnt", Animal = "Katt" },
    new OptionModel { OptionId = 9, QuestionId = 2, Option = "Ett tyst och stilla rum", Animal = "Kanin" },
    new OptionModel { OptionId = 10, QuestionId = 2, Option = "Ett hem fyllt med ljud och färg", Animal = "Fågel" },
    new OptionModel { OptionId = 11, QuestionId = 2, Option = "Ett hem som känns som ett akvarium, lugnt och fridfullt", Animal = "Akvarium" },
    new OptionModel { OptionId = 12, QuestionId = 2, Option = "I en miljö som är lite annorlunda och exotisk", Animal = "Reptil" },

        new OptionModel { OptionId = 13, QuestionId = 3, Option = "Jag gillar att spendera mycket tid utomhus och vara aktiv", Animal = "Hund" },
    new OptionModel { OptionId = 14, QuestionId = 3, Option = "Jag vill ha sällskap men utan att behöva vara aktiv hela tiden", Animal = "Katt" },
    new OptionModel { OptionId = 15, QuestionId = 3, Option = "Jag vill ha ett djur som kräver lite mindre tid och uppmärksamhet", Animal = "Kanin" },
    new OptionModel { OptionId = 16, QuestionId = 3, Option = "Jag gillar att pyssla och sköta om ett utrymme i mitt hem", Animal = "Fågel" },
    new OptionModel { OptionId = 17, QuestionId = 3, Option = "Jag vill ha något som är nästan självständigt", Animal = "Akvarium" },
    new OptionModel { OptionId = 18, QuestionId = 3, Option = "Jag gillar att skapa och underhålla en unik miljö", Animal = "Reptil" },

    // Question 4 options
    new OptionModel { OptionId = 19, QuestionId = 4, Option = "Sport och träning", Animal = "Hund" },
    new OptionModel { OptionId = 20, QuestionId = 4, Option = "Läsa eller titta på film", Animal = "Katt" },
    new OptionModel { OptionId = 21, QuestionId = 4, Option = "Pyssla eller hantverka", Animal = "Kanin" },
    new OptionModel { OptionId = 22, QuestionId = 4, Option = "Dekorera och designa", Animal = "Fågel" },
    new OptionModel { OptionId = 23, QuestionId = 4, Option = "Meditation eller stilla reflektion", Animal = "Akvarium" },
    new OptionModel { OptionId = 24, QuestionId = 4, Option = "Experimentera och lära mig nya saker", Animal = "Reptil" },

    // Question 5 options
    new OptionModel { OptionId = 25, QuestionId = 5, Option = "Jag går ut och rör på mig för att slappna av", Animal = "Hund" },
    new OptionModel { OptionId = 26, QuestionId = 5, Option = "Jag myser gärna med något varmt och mjukt", Animal = "Katt" },
    new OptionModel { OptionId = 27, QuestionId = 5, Option = "Jag finner lugn i att pyssla eller göra något kreativt", Animal = "Kanin" },
    new OptionModel { OptionId = 28, QuestionId = 5, Option = "Jag städar och organiserar för att rensa tankarna", Animal = "Fågel" },
    new OptionModel { OptionId = 29, QuestionId = 5, Option = "Jag tittar på något som ger mig frid, som fiskar som simmar", Animal = "Akvarium" },
    new OptionModel { OptionId = 30, QuestionId = 5, Option = "Jag utforskar något nytt och spännande för att distrahera mig", Animal = "Reptil" },

    // Question 6 options
    new OptionModel { OptionId = 31, QuestionId = 6, Option = "Jag vill ha en kompis att spendera mycket tid med", Animal = "Hund" },
    new OptionModel { OptionId = 32, QuestionId = 6, Option = "Jag vill ha ett djur som är självständigt men ändå socialt", Animal = "Katt" },
    new OptionModel { OptionId = 33, QuestionId = 6, Option = "Jag gillar små och lugna djur som inte kräver så mycket", Animal = "Kanin" },
    new OptionModel { OptionId = 34, QuestionId = 6, Option = "Jag gillar att ta hand om och underhålla ett vackert utrymme", Animal = "Fågel" },
    new OptionModel { OptionId = 35, QuestionId = 6, Option = "Jag vill ha något som är lätt att sköta", Animal = "Akvarium" },
    new OptionModel { OptionId = 36, QuestionId = 6, Option = "Jag vill ha något ovanligt och lärorikt att ta hand om", Animal = "Reptil" },

    // Question 7 options
    new OptionModel { OptionId = 37, QuestionId = 7, Option = "Jag är flexibel och gillar att anpassa mig", Animal = "Hund" },
    new OptionModel { OptionId = 38, QuestionId = 7, Option = "Jag tycker om ett hem där allt har sin plats men är inte överdrivet noggrann", Animal = "Katt" },
    new OptionModel { OptionId = 39, QuestionId = 7, Option = "Jag uppskattar ordning men med en touch av personlighet", Animal = "Kanin" },
    new OptionModel { OptionId = 40, QuestionId = 7, Option = "Jag älskar att ha ett perfekt organiserat och dekorerat hem", Animal = "Fågel" },
    new OptionModel { OptionId = 41, QuestionId = 7, Option = "Jag föredrar ett minimalistiskt och lugnt hem", Animal = "Akvarium" },
    new OptionModel { OptionId = 42, QuestionId = 7, Option = "Jag gillar att ha specifika utrymmen som är välplanerade", Animal = "Reptil" },

    // Question 8 options
    new OptionModel { OptionId = 43, QuestionId = 8, Option = "Jag är mycket social och älskar att vara med andra", Animal = "Hund" },
    new OptionModel { OptionId = 44, QuestionId = 8, Option = "Jag är social men uppskattar också min egen tid", Animal = "Katt" },
    new OptionModel { OptionId = 45, QuestionId = 8, Option = "Jag gillar att vara ensam men också att ha ett lugnt sällskap ibland", Animal = "Kanin" },
    new OptionModel { OptionId = 46, QuestionId = 8, Option = "Jag tycker om att prata och interagera med andra men på mitt eget sätt", Animal = "Fågel" },
    new OptionModel { OptionId = 47, QuestionId = 8, Option = "Jag trivs bäst i min egen värld, men kan njuta av att titta på andra", Animal = "Akvarium" },
    new OptionModel { OptionId = 48, QuestionId = 8, Option = "Jag är mer intresserad av att observera än att delta", Animal = "Reptil" },

    // Question 9 options
    new OptionModel { OptionId = 49, QuestionId = 9, Option = "Jag gillar att motionera och vara aktiv varje dag", Animal = "Hund" },
    new OptionModel { OptionId = 50, QuestionId = 9, Option = "Jag gillar att röra mig men föredrar mer avslappnade aktiviteter", Animal = "Katt" },
    new OptionModel { OptionId = 51, QuestionId = 9, Option = "Jag föredrar aktiviteter som är lugna och mindre intensiva", Animal = "Kanin" },
    new OptionModel { OptionId = 52, QuestionId = 9, Option = "Jag tycker om att ha rutiner men behöver inte mycket fysisk aktivitet", Animal = "Fågel" },
    new OptionModel { OptionId = 53, QuestionId = 9, Option = "Jag tycker om att sitta still och observera", Animal = "Akvarium" },
    new OptionModel { OptionId = 54, QuestionId = 9, Option = "Jag föredrar att utforska saker i min egen takt", Animal = "Reptil" },

    // Question 10 options
    new OptionModel { OptionId = 55, QuestionId = 10, Option = "Rutiner är mycket viktiga för mig", Animal = "Hund" },
    new OptionModel { OptionId = 56, QuestionId = 10, Option = "Jag gillar rutiner men kan vara flexibel när det behövs", Animal = "Katt" },
    new OptionModel { OptionId = 57, QuestionId = 10, Option = "Jag uppskattar rutiner men behöver också utrymme för frihet", Animal = "Kanin" },
    new OptionModel { OptionId = 58, QuestionId = 10, Option = "Jag har vissa rutiner men är inte beroende av dem", Animal = "Fågel" },
    new OptionModel { OptionId = 59, QuestionId = 10, Option = "Rutiner är viktiga för mig men jag följer dem på mitt eget sätt", Animal = "Akvarium" },
    new OptionModel { OptionId = 60, QuestionId = 10, Option = "Jag föredrar att vara flexibel och följa dagsformen", Animal = "Reptil" },

    // Question 11 options
    new OptionModel { OptionId = 61, QuestionId = 11, Option = "Jag föredrar ett sällskap som är lika aktivt som jag", Animal = "Hund" },
    new OptionModel { OptionId = 62, QuestionId = 11, Option = "Jag gillar sällskap men vill också ha tid för mig själv", Animal = "Katt" },
    new OptionModel { OptionId = 63, QuestionId = 11, Option = "Jag uppskattar ett lugnt och avslappnat sällskap", Animal = "Kanin" },
    new OptionModel { OptionId = 64, QuestionId = 11, Option = "Jag gillar ett sällskap som är pratsamt och uttrycksfullt", Animal = "Fågel" },
    new OptionModel { OptionId = 65, QuestionId = 11, Option = "Jag föredrar ett sällskap som är stillsamt och rogivande", Animal = "Akvarium" },
    new OptionModel { OptionId = 66, QuestionId = 11, Option = "Jag vill ha ett sällskap som är unikt och intressant", Animal = "Reptil" },

    // Question 12 options
    new OptionModel { OptionId = 67, QuestionId = 12, Option = "Jag är noggrann med städning och gillar att ha det rent och snyggt", Animal = "Hund" },
    new OptionModel { OptionId = 68, QuestionId = 12, Option = "Jag gillar att ha det rent men är inte överdrivet noggrann", Animal = "Katt" },
    new OptionModel { OptionId = 69, QuestionId = 12, Option = "Jag uppskattar ett rent hem men tycker inte att det behöver vara perfekt", Animal = "Kanin" },
    new OptionModel { OptionId = 70, QuestionId = 12, Option = "Jag tycker om att ha ett vackert och prydligt hem", Animal = "Fågel" },
    new OptionModel { OptionId = 71, QuestionId = 12, Option = "Jag gillar att ha det rent och enkelt", Animal = "Akvarium" },
    new OptionModel { OptionId = 72, QuestionId = 12, Option = "Jag är mer intresserad av att ha ett intressant och organiserat utrymme", Animal = "Reptil" },

    // Question 13 options
    new OptionModel { OptionId = 73, QuestionId = 13, Option = "Jag trivs bäst i ett hem med liv och rörelse", Animal = "Hund" },
    new OptionModel { OptionId = 74, QuestionId = 13, Option = "Jag tycker om att ha det lugnt men kan stå ut med lite ljud", Animal = "Katt" },
    new OptionModel { OptionId = 75, QuestionId = 13, Option = "Jag föredrar ett tyst och stilla hem", Animal = "Kanin" },
    new OptionModel { OptionId = 76, QuestionId = 13, Option = "Jag gillar att höra ljud från naturen, som fågelsång", Animal = "Fågel" },
    new OptionModel { OptionId = 77, QuestionId = 13, Option = "Jag föredrar en lugn och rogivande atmosfär", Animal = "Akvarium" },
    new OptionModel { OptionId = 78, QuestionId = 13, Option = "Jag gillar ett hem som är stilla men med lite variation", Animal = "Reptil" },

    // Question 14 options
    new OptionModel { OptionId = 79, QuestionId = 14, Option = "Jag tar gärna på mig ansvar och trivs med det", Animal = "Hund" },
    new OptionModel { OptionId = 80, QuestionId = 14, Option = "Jag gillar att ha ansvar men behöver också tid för mig själv", Animal = "Katt" },
    new OptionModel { OptionId = 81, QuestionId = 14, Option = "Jag föredrar att ha ett ansvar som inte är för tungt", Animal = "Kanin" },
    new OptionModel { OptionId = 82, QuestionId = 14, Option = "Jag gillar att ha ansvar för att ta hand om något vackert", Animal = "Fågel" },
    new OptionModel { OptionId = 83, QuestionId = 14, Option = "Jag gillar att ha ansvar men på ett sätt som är enkelt och lugnt", Animal = "Akvarium" },
    new OptionModel { OptionId = 84, QuestionId = 14, Option = "Jag tar gärna på mig ansvar för något unikt och spännande", Animal = "Reptil" },

    // Question 15 options
    new OptionModel { OptionId = 85, QuestionId = 15, Option = "Jag älskar att ha besök och är en utmärkt värd", Animal = "Hund" },
    new OptionModel { OptionId = 86, QuestionId = 15, Option = "Jag gillar att ha besök men också min egen tid", Animal = "Katt" },
    new OptionModel { OptionId = 87, QuestionId = 15, Option = "Jag föredrar mindre sällskap och lugna besök", Animal = "Kanin" },
    new OptionModel { OptionId = 88, QuestionId = 15, Option = "Jag gillar att dekorera och göra hemmet inbjudande för besökare", Animal = "Fågel" },
    new OptionModel { OptionId = 89, QuestionId = 15, Option = "Jag trivs bäst när jag kan ha mitt eget utrymme, även när jag har besök", Animal = "Akvarium" },
    new OptionModel { OptionId = 90, QuestionId = 15, Option = "Jag gillar att ha besök men vill inte att det blir för ofta", Animal = "Reptil" }
);






            // Seed PostModel...
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

            // Seed InterestModel...
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

            // Seed ReviewModel...
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
                .OnDelete(DeleteBehavior.Restrict);

            // Configure composite key for InterestModel
            modelBuilder.Entity<InterestModel>()
                .HasKey(i => new { i.ApplicationUserId, i.PostId });

            // ApplicationUser to InterestModel (1 to Many)
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Interests)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // PostModel to InterestModel (1 to Many)
            modelBuilder.Entity<PostModel>()
                .HasMany(p => p.Interests)
                .WithOne(i => i.PostModel)
                .HasForeignKey(i => i.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            // ApplicationUser to ReviewModel (Written Reviews) (1 to Many)
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.ReviewsWritten)
                .WithOne(r => r.Reviewer)
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            // ApplicationUser to ReviewModel (Received Reviews) (1 to Many)
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.ReviewsRecieved)
                .WithOne(r => r.ReviewedSeller)
                .HasForeignKey(r => r.ReviewedSellerId)
                .OnDelete(DeleteBehavior.Restrict);

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

            // one-to-many relationship between QuestionModel and OptionModel
            modelBuilder.Entity<QuestionModel>()
                .HasMany(q => q.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            // one-to-many relationship between QuizModel and QuestionModel
            modelBuilder.Entity<QuizModel>()
                .HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
