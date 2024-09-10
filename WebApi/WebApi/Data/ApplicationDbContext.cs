using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<InterestModel> Interests { get; set; }
        public DbSet<BookmarkModel> Bookmarks { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<QuizModel> Quizzes { get; set; }
        public DbSet<OptionModel> Options { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<ReportModel> Reports { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        private void SeedUsers(ModelBuilder builder)
        {
            const string ADMIN_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            const string ROLE_ID = ADMIN_ID;


            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });


            ApplicationUser admin = new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "Admin@petnet.com",
                NormalizedUserName = "ADMIN@PETNET.COM",
                Email = "admin@petnet.com",
                NormalizedEmail = "ADMIN@PETNET.COM",
                IsVerified = true,
                EmailConfirmed = true,

            };

            ApplicationUser user1 = new ApplicationUser
            {
                Id = "user1",
                UserName = "user1@example.com",
                Email = "user1@example.com",
                NormalizedUserName = "USER1@EXAMPLE.COM",
                NormalizedEmail = "USER1@EXAMPLE.COM",
                IsPrivateSeller = true,
                IsVerified = true
            };

            ApplicationUser user2 = new ApplicationUser
            {
                Id = "user2",
                UserName = "user2@example.com",
                Email = "user2@example.com",
                NormalizedUserName = "USER2@EXAMPLE.COM",
                NormalizedEmail = "USER2@EXAMPLE.COM",
                IsPrivateSeller = false,
                IsVerified = false
            };


            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            user1.PasswordHash = passwordHasher.HashPassword(user1, "user1*123");
            user2.PasswordHash = passwordHasher.HashPassword(user2, "user2*123");
            admin.PasswordHash = passwordHasher.HashPassword(null, "Admin1!");
            builder.Entity<ApplicationUser>().HasData(user1, user2, admin);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<QuizModel>().HasData(
         new QuizModel
         {
             QuizId = 1,
             Title = "Vilket djur passar dig bäst?",
             Info = "Välkommen till vårt husdjursquiz! Att välja rätt husdjur är ett stort beslut som bör baseras på din livsstil, personlighet och preferenser. I det här testet kommer du att besvara 15 frågor som hjälper dig att upptäcka vilket djur som passar bäst för just dig. Oavsett om du är en aktiv person som älskar att vara utomhus eller om du föredrar en lugn och stillsam miljö, så finns det ett husdjur som passar din vardag perfekt. Svara ärligt på frågorna, så får du snart veta vilken typ av husdjur som skulle bli din bästa vän!",
             Dog = "Hundar är sociala, lojala och ofta fulla av energi. De är fantastiska följeslagare för dem som gillar att vara aktiva och spendera tid utomhus. Hundar kräver dagliga promenader, mental stimulans, och en hel del uppmärksamhet och kärlek.\r\n\r\nSkötsel:\r\nAtt ha en hund innebär ett stort ansvar. Förutom dagliga promenader och regelbunden motion behöver hundar också träning, socialisering, och regelbunden veterinärvård. Hundar älskar att vara en del av familjen och kräver mycket tid och engagemang från sina ägare.\r\n\r\nSaker att tänka på:\r\nInnan du skaffar en hund, tänk på att de behöver mycket tid och energi. De flesta hundar gillar inte att vara ensamma under längre perioder, så se till att din livsstil kan anpassas efter deras behov. Räkna också med kostnader för mat, veterinärbesök, försäkringar och eventuella oväntade utgifter.\r\n",
             Cat = "Katter är självständiga och nyfikna djur som älskar att utforska och samtidigt njuta av långa stunder av vila. De kan vara kärleksfulla och sociala, men de har också en stark egen vilja och uppskattar ofta sitt eget sällskap.\r\n\r\nSkötsel:\r\nKatter är relativt lättskötta jämfört med många andra husdjur. De behöver daglig mat, vatten, och en ren kattlåda. Katter kräver också lite lektid och mental stimulans, särskilt inomhuskatter. Regelbunden veterinärvård är också viktigt för att hålla din katt frisk.\r\n\r\nSaker att tänka på:\r\nKatter kan vara ganska självständiga, vilket gör dem idealiska för människor med hektiska scheman. Men de behöver fortfarande uppmärksamhet och omsorg. Tänk på att katter kan ha olika personligheter, från väldigt sociala till mer reserverade. Fundera på om du vill ha en inomhus- eller utomhuskatt och hur du kan göra ditt hem kattvänligt.\r\n",
             Rabbit = "Kaniner är tysta, sällskapliga djur som trivs bäst i ett lugnt och säkert hem. De är ofta lekfulla och kan skapa starka band med sina ägare, men de är också känsliga och kräver ett särskilt omhändertagande.\r\n\r\nSkötsel:\r\nKaniner behöver en rymlig bur eller ett område där de kan röra sig fritt. Deras kost består främst av hö, grönsaker och pellets. Det är också viktigt att erbjuda dem leksaker och aktiviteter för att hålla dem mentalt stimulerade. Regelbunden rengöring av deras bur och veterinärbesök är också nödvändiga.\r\n\r\nSaker att tänka på:\r\nKaniner är känsliga djur som kräver en lugn miljö. De passar bra för personer som kan erbjuda en stabil och tyst hemmiljö. Kaniner kan leva ganska länge, så det är viktigt att vara beredd på ett långsiktigt åtagande. De är också sociala djur och kan ibland må bäst av att ha en annan kanin som sällskap.",
             Bird = "Fåglar är färgglada, intelligenta och kan vara mycket sociala. De älskar att interagera med sina ägare och vissa arter kan till och med lära sig att prata. Fåglar kräver dock mycket mental stimulans och ett tryggt hem.\r\n\r\nSkötsel:\r\nAtt ta hand om en fågel innebär att ge dem en stor, säker bur med utrymme att flyga och leka. Deras kost ska vara varierad och näringsrik, inklusive fröer, frukt och grönsaker. Fåglar behöver daglig uppmärksamhet och interaktion, samt leksaker för att hålla dem underhållna.\r\n\r\nSaker att tänka på:\r\nFåglar kan leva länge, ibland upp till flera decennier beroende på art, så det är ett långsiktigt åtagande. De kan också vara högljudda och röriga, så se till att du är beredd på detta. Det är viktigt att förstå fåglars sociala behov och att de kan bli stressade om de lämnas ensamma för länge.\r\n",
             Aquarium = "Ett akvarium med fiskar kan vara en lugnande och vacker del av ditt hem. Fiskar är tysta och kräver inte mycket interaktion, men de behöver en välskött miljö för att trivas.\r\n\r\nSkötsel:\r\nSkötsel av ett akvarium innebär att regelbundet byta vatten, kontrollera vattenkvaliteten och se till att filtren fungerar korrekt. Fiskar behöver rätt typ av mat, och det är viktigt att välja fiskar som trivs tillsammans. Ett akvarium kräver också en noggrann inställning till temperatur och belysning.\r\n\r\nSaker att tänka på:\r\nFiskar är känsliga för förändringar i sin miljö, så det är viktigt att vara noggrann med vattenkvalitet och skötsel. Ett akvarium kan vara ett vackert tillskott till ditt hem, men det kräver tid och engagemang för att underhålla. Fundera på om du vill ha ett sötvatten- eller saltvattenakvarium, då de har olika krav.\r\n",
             Reptile = "Reptiler är fascinerande och unika husdjur som kräver en speciell typ av skötsel. De kan vara ganska självständiga och är ofta mest lämpade för ägare som är intresserade av att skapa en specifik miljö och förstå deras unika behov.\r\n\r\nSkötsel:\r\nReptiler, såsom ormar, ödlor och sköldpaddor, kräver ett specialanpassat terrarium med rätt temperatur, belysning och luftfuktighet. Deras kost varierar beroende på art, från insekter till grönt foder. Regelbunden rengöring av terrariet och kontroll av deras miljö är avgörande för deras hälsa.\r\n\r\nSaker att tänka på:\r\nReptiler kan vara känsliga för förändringar i sin omgivning och kräver noggrann övervakning av deras livsmiljö. De är inte lika sociala som andra husdjur och kan vara mindre interaktiva, vilket är viktigt att överväga om du vill ha ett djur som du kan hantera ofta. Reptiler är bäst lämpade för dem som har ett särskilt intresse för dessa fascinerande djur och är villiga att investera tid i att skapa och underhålla deras miljö.\r\n\r\n"

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
    new OptionModel { OptionId = 1, QuestionId = 1, Option = "Jag älskar att vara ute och vara aktiv", Animal = "Dog" },
    new OptionModel { OptionId = 2, QuestionId = 1, Option = "Ligga i soffan och mysa med en bra film", Animal = "Cat" },
    new OptionModel { OptionId = 3, QuestionId = 1, Option = "Läsa en bok eller pyssla i trädgården", Animal = "Rabbit" },
    new OptionModel { OptionId = 4, QuestionId = 1, Option = "Organisera och dekorera hemmet", Animal = "Bird" },
    new OptionModel { OptionId = 5, QuestionId = 1, Option = "Njuta av ett lugnt och stilla hem", Animal = "Aquarium" },
    new OptionModel { OptionId = 6, QuestionId = 1, Option = "Upptäcka nya intressen och hobbyer", Animal = "Reptile" },

    // Question 2 options
    new OptionModel { OptionId = 7, QuestionId = 2, Option = "Ute i naturen, kanske i en park eller skog", Animal = "Dog" },
    new OptionModel { OptionId = 8, QuestionId = 2, Option = "Inomhus, där jag kan ta det lugnt", Animal = "Cat" },
    new OptionModel { OptionId = 9, QuestionId = 2, Option = "Ett tyst och stilla rum", Animal = "Rabbit" },
    new OptionModel { OptionId = 10, QuestionId = 2, Option = "Ett hem fyllt med ljud och färg", Animal = "Bird" },
    new OptionModel { OptionId = 11, QuestionId = 2, Option = "Ett hem som känns som ett akvarium, lugnt och fridfullt", Animal = "Aquarium" },
    new OptionModel { OptionId = 12, QuestionId = 2, Option = "I en miljö som är lite annorlunda och exotisk", Animal = "Reptile" },

        new OptionModel { OptionId = 13, QuestionId = 3, Option = "Jag gillar att spendera mycket tid utomhus och vara aktiv", Animal = "Dog" },
    new OptionModel { OptionId = 14, QuestionId = 3, Option = "Jag vill ha sällskap men utan att behöva vara aktiv hela tiden", Animal = "Cat" },
    new OptionModel { OptionId = 15, QuestionId = 3, Option = "Jag vill ha ett djur som kräver lite mindre tid och uppmärksamhet", Animal = "Rabbit" },
    new OptionModel { OptionId = 16, QuestionId = 3, Option = "Jag gillar att pyssla och sköta om ett utrymme i mitt hem", Animal = "Bird" },
    new OptionModel { OptionId = 17, QuestionId = 3, Option = "Jag vill ha något som är nästan självständigt", Animal = "Aquarium" },
    new OptionModel { OptionId = 18, QuestionId = 3, Option = "Jag gillar att skapa och underhålla en unik miljö", Animal = "Reptile" },

    // Question 4 options
    new OptionModel { OptionId = 19, QuestionId = 4, Option = "Sport och träning", Animal = "Dog" },
    new OptionModel { OptionId = 20, QuestionId = 4, Option = "Läsa eller titta på film", Animal = "Cat" },
    new OptionModel { OptionId = 21, QuestionId = 4, Option = "Pyssla eller hantverka", Animal = "Rabbit" },
    new OptionModel { OptionId = 22, QuestionId = 4, Option = "Dekorera och designa", Animal = "Bird" },
    new OptionModel { OptionId = 23, QuestionId = 4, Option = "Meditation eller stilla reflektion", Animal = "Aquarium" },
    new OptionModel { OptionId = 24, QuestionId = 4, Option = "Experimentera och lära mig nya saker", Animal = "Reptile" },

    // Question 5 options
    new OptionModel { OptionId = 25, QuestionId = 5, Option = "Jag går ut och rör på mig för att slappna av", Animal = "Dog" },
    new OptionModel { OptionId = 26, QuestionId = 5, Option = "Jag myser gärna med något varmt och mjukt", Animal = "Cat" },
    new OptionModel { OptionId = 27, QuestionId = 5, Option = "Jag finner lugn i att pyssla eller göra något kreativt", Animal = "Rabbit" },
    new OptionModel { OptionId = 28, QuestionId = 5, Option = "Jag städar och organiserar för att rensa tankarna", Animal = "Bird" },
    new OptionModel { OptionId = 29, QuestionId = 5, Option = "Jag tittar på något som ger mig frid, som fiskar som simmar", Animal = "Aquarium" },
    new OptionModel { OptionId = 30, QuestionId = 5, Option = "Jag utforskar något nytt och spännande för att distrahera mig", Animal = "Reptile" },

    // Question 6 options
    new OptionModel { OptionId = 31, QuestionId = 6, Option = "Jag vill ha en kompis att spendera mycket tid med", Animal = "Dog" },
    new OptionModel { OptionId = 32, QuestionId = 6, Option = "Jag vill ha ett djur som är självständigt men ändå socialt", Animal = "Cat" },
    new OptionModel { OptionId = 33, QuestionId = 6, Option = "Jag gillar små och lugna djur som inte kräver så mycket", Animal = "Rabbit" },
    new OptionModel { OptionId = 34, QuestionId = 6, Option = "Jag gillar att ta hand om och underhålla ett vackert utrymme", Animal = "Bird" },
    new OptionModel { OptionId = 35, QuestionId = 6, Option = "Jag vill ha något som är lätt att sköta", Animal = "Aquarium" },
    new OptionModel { OptionId = 36, QuestionId = 6, Option = "Jag vill ha något ovanligt och lärorikt att ta hand om", Animal = "Reptile" },

    // Question 7 options
    new OptionModel { OptionId = 37, QuestionId = 7, Option = "Jag är flexibel och gillar att anpassa mig", Animal = "Dog" },
    new OptionModel { OptionId = 38, QuestionId = 7, Option = "Jag tycker om ett hem där allt har sin plats men är inte överdrivet noggrann", Animal = "Cat" },
    new OptionModel { OptionId = 39, QuestionId = 7, Option = "Jag uppskattar ordning men med en touch av personlighet", Animal = "Rabbit" },
    new OptionModel { OptionId = 40, QuestionId = 7, Option = "Jag älskar att ha ett perfekt organiserat och dekorerat hem", Animal = "Bird" },
    new OptionModel { OptionId = 41, QuestionId = 7, Option = "Jag föredrar ett minimalistiskt och lugnt hem", Animal = "Aquarium" },
    new OptionModel { OptionId = 42, QuestionId = 7, Option = "Jag gillar att ha specifika utrymmen som är välplanerade", Animal = "Reptile" },

    // Question 8 options
    new OptionModel { OptionId = 43, QuestionId = 8, Option = "Jag är mycket social och älskar att vara med andra", Animal = "Dog" },
    new OptionModel { OptionId = 44, QuestionId = 8, Option = "Jag är social men uppskattar också min egen tid", Animal = "Cat" },
    new OptionModel { OptionId = 45, QuestionId = 8, Option = "Jag gillar att vara ensam men också att ha ett lugnt sällskap ibland", Animal = "Rabbit" },
    new OptionModel { OptionId = 46, QuestionId = 8, Option = "Jag tycker om att prata och interagera med andra men på mitt eget sätt", Animal = "Bird" },
    new OptionModel { OptionId = 47, QuestionId = 8, Option = "Jag trivs bäst i min egen värld, men kan njuta av att titta på andra", Animal = "Aquarium" },
    new OptionModel { OptionId = 48, QuestionId = 8, Option = "Jag är mer intresserad av att observera än att delta", Animal = "Reptile" },

    // Question 9 options
    new OptionModel { OptionId = 49, QuestionId = 9, Option = "Jag gillar att motionera och vara aktiv varje dag", Animal = "Dog" },
    new OptionModel { OptionId = 50, QuestionId = 9, Option = "Jag gillar att röra mig men föredrar mer avslappnade aktiviteter", Animal = "Cat" },
    new OptionModel { OptionId = 51, QuestionId = 9, Option = "Jag föredrar aktiviteter som är lugna och mindre intensiva", Animal = "Rabbit" },
    new OptionModel { OptionId = 52, QuestionId = 9, Option = "Jag tycker om att ha rutiner men behöver inte mycket fysisk aktivitet", Animal = "Bird" },
    new OptionModel { OptionId = 53, QuestionId = 9, Option = "Jag tycker om att sitta still och observera", Animal = "Aquarium" },
    new OptionModel { OptionId = 54, QuestionId = 9, Option = "Jag föredrar att utforska saker i min egen takt", Animal = "Reptile" },

    // Question 10 options
    new OptionModel { OptionId = 55, QuestionId = 10, Option = "Rutiner är mycket viktiga för mig", Animal = "Dog" },
    new OptionModel { OptionId = 56, QuestionId = 10, Option = "Jag gillar rutiner men kan vara flexibel när det behövs", Animal = "Cat" },
    new OptionModel { OptionId = 57, QuestionId = 10, Option = "Jag uppskattar rutiner men behöver också utrymme för frihet", Animal = "Rabbit" },
    new OptionModel { OptionId = 58, QuestionId = 10, Option = "Jag har vissa rutiner men är inte beroende av dem", Animal = "Bird" },
    new OptionModel { OptionId = 59, QuestionId = 10, Option = "Rutiner är viktiga för mig men jag följer dem på mitt eget sätt", Animal = "Aquarium" },
    new OptionModel { OptionId = 60, QuestionId = 10, Option = "Jag föredrar att vara flexibel och följa dagsformen", Animal = "Reptile" },

    // Question 11 options
    new OptionModel { OptionId = 61, QuestionId = 11, Option = "Jag föredrar ett sällskap som är lika aktivt som jag", Animal = "Dog" },
    new OptionModel { OptionId = 62, QuestionId = 11, Option = "Jag gillar sällskap men vill också ha tid för mig själv", Animal = "Cat" },
    new OptionModel { OptionId = 63, QuestionId = 11, Option = "Jag uppskattar ett lugnt och avslappnat sällskap", Animal = "Rabbit" },
    new OptionModel { OptionId = 64, QuestionId = 11, Option = "Jag gillar ett sällskap som är pratsamt och uttrycksfullt", Animal = "Bird" },
    new OptionModel { OptionId = 65, QuestionId = 11, Option = "Jag föredrar ett sällskap som är stillsamt och rogivande", Animal = "Aquarium" },
    new OptionModel { OptionId = 66, QuestionId = 11, Option = "Jag vill ha ett sällskap som är unikt och intressant", Animal = "Reptile" },

    // Question 12 options
    new OptionModel { OptionId = 67, QuestionId = 12, Option = "Jag är noggrann med städning och gillar att ha det rent och snyggt", Animal = "Dog" },
    new OptionModel { OptionId = 68, QuestionId = 12, Option = "Jag gillar att ha det rent men är inte överdrivet noggrann", Animal = "Cat" },
    new OptionModel { OptionId = 69, QuestionId = 12, Option = "Jag uppskattar ett rent hem men tycker inte att det behöver vara perfekt", Animal = "Rabbit" },
    new OptionModel { OptionId = 70, QuestionId = 12, Option = "Jag tycker om att ha ett vackert och prydligt hem", Animal = "Bird" },
    new OptionModel { OptionId = 71, QuestionId = 12, Option = "Jag gillar att ha det rent och enkelt", Animal = "Aquarium" },
    new OptionModel { OptionId = 72, QuestionId = 12, Option = "Jag är mer intresserad av att ha ett intressant och organiserat utrymme", Animal = "Reptile" },

    // Question 13 options
    new OptionModel { OptionId = 73, QuestionId = 13, Option = "Jag trivs bäst i ett hem med liv och rörelse", Animal = "Dog" },
    new OptionModel { OptionId = 74, QuestionId = 13, Option = "Jag tycker om att ha det lugnt men kan stå ut med lite ljud", Animal = "Cat" },
    new OptionModel { OptionId = 75, QuestionId = 13, Option = "Jag föredrar ett tyst och stilla hem", Animal = "Rabbit" },
    new OptionModel { OptionId = 76, QuestionId = 13, Option = "Jag gillar att höra ljud från naturen, som fågelsång", Animal = "Bird" },
    new OptionModel { OptionId = 77, QuestionId = 13, Option = "Jag föredrar en lugn och rogivande atmosfär", Animal = "Aquarium" },
    new OptionModel { OptionId = 78, QuestionId = 13, Option = "Jag gillar ett hem som är stilla men med lite variation", Animal = "Reptile" },

    // Question 14 options
    new OptionModel { OptionId = 79, QuestionId = 14, Option = "Jag tar gärna på mig ansvar och trivs med det", Animal = "Dog" },
    new OptionModel { OptionId = 80, QuestionId = 14, Option = "Jag gillar att ha ansvar men behöver också tid för mig själv", Animal = "Cat" },
    new OptionModel { OptionId = 81, QuestionId = 14, Option = "Jag föredrar att ha ett ansvar som inte är för tungt", Animal = "Rabbit" },
    new OptionModel { OptionId = 82, QuestionId = 14, Option = "Jag gillar att ha ansvar för att ta hand om något vackert", Animal = "Bird" },
    new OptionModel { OptionId = 83, QuestionId = 14, Option = "Jag gillar att ha ansvar men på ett sätt som är enkelt och lugnt", Animal = "Aquarium" },
    new OptionModel { OptionId = 84, QuestionId = 14, Option = "Jag tar gärna på mig ansvar för något unikt och spännande", Animal = "Reptile" },

    // Question 15 options
    new OptionModel { OptionId = 85, QuestionId = 15, Option = "Jag älskar att ha besök och är en utmärkt värd", Animal = "Dog" },
    new OptionModel { OptionId = 86, QuestionId = 15, Option = "Jag gillar att ha besök men också min egen tid", Animal = "Cat" },
    new OptionModel { OptionId = 87, QuestionId = 15, Option = "Jag föredrar mindre sällskap och lugna besök", Animal = "Rabbit" },
    new OptionModel { OptionId = 88, QuestionId = 15, Option = "Jag gillar att dekorera och göra hemmet inbjudande för besökare", Animal = "Bird" },
    new OptionModel { OptionId = 89, QuestionId = 15, Option = "Jag trivs bäst när jag kan ha mitt eget utrymme, även när jag har besök", Animal = "Aquarium" },
    new OptionModel { OptionId = 90, QuestionId = 15, Option = "Jag gillar att ha besök men vill inte att det blir för ofta", Animal = "Reptile" }
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
                    ApplicationUserId = "user1", // FK to ApplicationUser
                    Gender = "Male",
                    DateOfBirth = DateOnly.Parse("2020-11-01"),
                    Images = new List<string>
                    {
                        "https://www.marthastewart.com/thmb/Ki1fnPkHDxYQv_kAN2HtBxwOELY=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/happy-labrador-retriever-getty-0322-2000-eb585d9e672e47da8b1b7e9d3215a5cb.jpg"
                    }

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
                    ApplicationUserId = "user2", // FK to ApplicationUser
                    Gender = "Female",
                    DateOfBirth = DateOnly.Parse("2021-11-01"),
                    Images = new List<string>
                    {
                        "https://www.purina.co.uk/sites/default/files/styles/square_medium_440x440/public/2022-06/Siamese-Cat_0.jpg?itok=Qy1J6ZDS"
                    }
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






            // Configure composite key for BookmarkModel
            modelBuilder.Entity<BookmarkModel>()
                .HasKey(i => new { i.ApplicationUserId, i.PostModelId });




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
                .OnDelete(DeleteBehavior.Cascade);

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
