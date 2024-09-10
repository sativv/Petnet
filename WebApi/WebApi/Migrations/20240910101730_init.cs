using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuizResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrivateSeller = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationNumber = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuisnessContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rabbit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bird = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aquarium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reptile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.QuizId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonOfReport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendedReportUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportedUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeReported = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    AnimalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalBreed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IsAdoptionReady = table.Column<bool>(type: "bit", nullable: false),
                    EarliestDelivery = table.Column<DateOnly>(type: "date", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReviewedSellerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_ReviewedSellerId",
                        column: x => x.ReviewedSellerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookmarks",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmarks", x => new { x.ApplicationUserId, x.PostModelId });
                    table.ForeignKey(
                        name: "FK_Bookmarks_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookmarks_Posts_PostModelId",
                        column: x => x.PostModelId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => new { x.ApplicationUserId, x.PostId });
                    table.ForeignKey(
                        name: "FK_Interests_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interests_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Animal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AboutMe", "AccessFailedCount", "Adress", "BuisnessContact", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsPrivateSeller", "IsVerified", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OrganizationName", "OrganizationNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Postcode", "QuizResult", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", null, 0, null, null, null, "78141341-ad12-47a3-b200-703144e32eca", "admin@petnet.com", true, false, true, false, null, "ADMIN@PETNET.COM", "ADMIN@PETNET.COM", null, 0L, "AQAAAAIAAYagAAAAEAf9iwALSeiN6yX6uQ+ack6+xGyZb3t1MaT5x0UEWshoHgt3kBABn/KXsG99TIGpKw==", null, false, 0, null, "2c87b445-978b-4ba3-bdb6-6ccb142c61e6", false, "Admin@petnet.com" },
                    { "user1", null, 0, null, null, null, "50ca916c-aa0e-4d8a-bfc4-5f6d814688b6", "user1@example.com", false, true, true, false, null, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", null, 0L, "AQAAAAIAAYagAAAAEKRJ3p06Xp10nDdtC6oNX7acTHwLevhH5nNukJmmuqJoCUtBUpuW4HQxjt0rGNLCaw==", null, false, 0, null, "0f8afa52-5328-4971-8962-501c8eb177aa", false, "user1@example.com" },
                    { "user2", null, 0, null, null, null, "7cf3ffe2-4b24-4eb0-8504-cffde6994709", "user2@example.com", false, false, false, false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, 0L, "AQAAAAIAAYagAAAAELnZudQWCKFu6pRjeE1/rZc5KtQR8IcUd3c/CCVFg1qw7W78143c7NlnYA3PrRrdZg==", null, false, 0, null, "cd741db5-d5ec-4513-b9ff-67b7fe6e54a0", false, "user2@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "QuizId", "Aquarium", "Bird", "Cat", "Dog", "Info", "Rabbit", "Reptile", "Title" },
                values: new object[] { 1, "Ett akvarium med fiskar kan vara en lugnande och vacker del av ditt hem. Fiskar är tysta och kräver inte mycket interaktion, men de behöver en välskött miljö för att trivas.\r\n\r\nSkötsel:\r\nSkötsel av ett akvarium innebär att regelbundet byta vatten, kontrollera vattenkvaliteten och se till att filtren fungerar korrekt. Fiskar behöver rätt typ av mat, och det är viktigt att välja fiskar som trivs tillsammans. Ett akvarium kräver också en noggrann inställning till temperatur och belysning.\r\n\r\nSaker att tänka på:\r\nFiskar är känsliga för förändringar i sin miljö, så det är viktigt att vara noggrann med vattenkvalitet och skötsel. Ett akvarium kan vara ett vackert tillskott till ditt hem, men det kräver tid och engagemang för att underhålla. Fundera på om du vill ha ett sötvatten- eller saltvattenakvarium, då de har olika krav.\r\n", "Fåglar är färgglada, intelligenta och kan vara mycket sociala. De älskar att interagera med sina ägare och vissa arter kan till och med lära sig att prata. Fåglar kräver dock mycket mental stimulans och ett tryggt hem.\r\n\r\nSkötsel:\r\nAtt ta hand om en fågel innebär att ge dem en stor, säker bur med utrymme att flyga och leka. Deras kost ska vara varierad och näringsrik, inklusive fröer, frukt och grönsaker. Fåglar behöver daglig uppmärksamhet och interaktion, samt leksaker för att hålla dem underhållna.\r\n\r\nSaker att tänka på:\r\nFåglar kan leva länge, ibland upp till flera decennier beroende på art, så det är ett långsiktigt åtagande. De kan också vara högljudda och röriga, så se till att du är beredd på detta. Det är viktigt att förstå fåglars sociala behov och att de kan bli stressade om de lämnas ensamma för länge.\r\n", "Katter är självständiga och nyfikna djur som älskar att utforska och samtidigt njuta av långa stunder av vila. De kan vara kärleksfulla och sociala, men de har också en stark egen vilja och uppskattar ofta sitt eget sällskap.\r\n\r\nSkötsel:\r\nKatter är relativt lättskötta jämfört med många andra husdjur. De behöver daglig mat, vatten, och en ren kattlåda. Katter kräver också lite lektid och mental stimulans, särskilt inomhuskatter. Regelbunden veterinärvård är också viktigt för att hålla din katt frisk.\r\n\r\nSaker att tänka på:\r\nKatter kan vara ganska självständiga, vilket gör dem idealiska för människor med hektiska scheman. Men de behöver fortfarande uppmärksamhet och omsorg. Tänk på att katter kan ha olika personligheter, från väldigt sociala till mer reserverade. Fundera på om du vill ha en inomhus- eller utomhuskatt och hur du kan göra ditt hem kattvänligt.\r\n", "Hundar är sociala, lojala och ofta fulla av energi. De är fantastiska följeslagare för dem som gillar att vara aktiva och spendera tid utomhus. Hundar kräver dagliga promenader, mental stimulans, och en hel del uppmärksamhet och kärlek.\r\n\r\nSkötsel:\r\nAtt ha en hund innebär ett stort ansvar. Förutom dagliga promenader och regelbunden motion behöver hundar också träning, socialisering, och regelbunden veterinärvård. Hundar älskar att vara en del av familjen och kräver mycket tid och engagemang från sina ägare.\r\n\r\nSaker att tänka på:\r\nInnan du skaffar en hund, tänk på att de behöver mycket tid och energi. De flesta hundar gillar inte att vara ensamma under längre perioder, så se till att din livsstil kan anpassas efter deras behov. Räkna också med kostnader för mat, veterinärbesök, försäkringar och eventuella oväntade utgifter.\r\n", "Välkommen till vårt husdjursquiz! Att välja rätt husdjur är ett stort beslut som bör baseras på din livsstil, personlighet och preferenser. I det här testet kommer du att besvara 15 frågor som hjälper dig att upptäcka vilket djur som passar bäst för just dig. Oavsett om du är en aktiv person som älskar att vara utomhus eller om du föredrar en lugn och stillsam miljö, så finns det ett husdjur som passar din vardag perfekt. Svara ärligt på frågorna, så får du snart veta vilken typ av husdjur som skulle bli din bästa vän!", "Kaniner är tysta, sällskapliga djur som trivs bäst i ett lugnt och säkert hem. De är ofta lekfulla och kan skapa starka band med sina ägare, men de är också känsliga och kräver ett särskilt omhändertagande.\r\n\r\nSkötsel:\r\nKaniner behöver en rymlig bur eller ett område där de kan röra sig fritt. Deras kost består främst av hö, grönsaker och pellets. Det är också viktigt att erbjuda dem leksaker och aktiviteter för att hålla dem mentalt stimulerade. Regelbunden rengöring av deras bur och veterinärbesök är också nödvändiga.\r\n\r\nSaker att tänka på:\r\nKaniner är känsliga djur som kräver en lugn miljö. De passar bra för personer som kan erbjuda en stabil och tyst hemmiljö. Kaniner kan leva ganska länge, så det är viktigt att vara beredd på ett långsiktigt åtagande. De är också sociala djur och kan ibland må bäst av att ha en annan kanin som sällskap.", "Reptiler är fascinerande och unika husdjur som kräver en speciell typ av skötsel. De kan vara ganska självständiga och är ofta mest lämpade för ägare som är intresserade av att skapa en specifik miljö och förstå deras unika behov.\r\n\r\nSkötsel:\r\nReptiler, såsom ormar, ödlor och sköldpaddor, kräver ett specialanpassat terrarium med rätt temperatur, belysning och luftfuktighet. Deras kost varierar beroende på art, från insekter till grönt foder. Regelbunden rengöring av terrariet och kontroll av deras miljö är avgörande för deras hälsa.\r\n\r\nSaker att tänka på:\r\nReptiler kan vara känsliga för förändringar i sin omgivning och kräver noggrann övervakning av deras livsmiljö. De är inte lika sociala som andra husdjur och kan vara mindre interaktiva, vilket är viktigt att överväga om du vill ha ett djur som du kan hantera ofta. Reptiler är bäst lämpade för dem som har ett särskilt intresse för dessa fascinerande djur och är villiga att investera tid i att skapa och underhålla deras miljö.\r\n\r\n", "Vilket djur passar dig bäst?" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "b4280b6a-0613-4cbd-a9e6-f1701e926e73" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Age", "AnimalBreed", "AnimalType", "ApplicationUserId", "DateOfBirth", "Description", "EarliestDelivery", "Gender", "Images", "IsAdoptionReady", "Title" },
                values: new object[,]
                {
                    { 1, 2, "Labrador", "Dog", "user1", new DateOnly(2020, 11, 1), "Description for post 1", new DateOnly(2024, 9, 1), "Male", "[\"https://www.marthastewart.com/thmb/Ki1fnPkHDxYQv_kAN2HtBxwOELY=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/happy-labrador-retriever-getty-0322-2000-eb585d9e672e47da8b1b7e9d3215a5cb.jpg\"]", true, "Post 1" },
                    { 2, 1, "Siamese", "Cat", "user2", new DateOnly(2021, 11, 1), "Description for post 2", new DateOnly(2024, 10, 1), "Female", "[\"https://www.purina.co.uk/sites/default/files/styles/square_medium_440x440/public/2022-06/Siamese-Cat_0.jpg?itok=Qy1J6ZDS\"]", false, "Post 2" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "QuizId", "Text" },
                values: new object[,]
                {
                    { 1, 1, "Hur ser en perfekt helg ut för dig?" },
                    { 2, 1, "Vilken miljö trivs du bäst i?" },
                    { 3, 1, "Hur mycket tid vill du lägga på ditt husdjur?" },
                    { 4, 1, "Vad är din favorit typ av aktivitet?" },
                    { 5, 1, "Hur hanterar du stress?" },
                    { 6, 1, "Hur ser du på att ta hand om ett husdjur?" },
                    { 7, 1, "Hur viktigt är det för dig att ditt hem är organiserat?" },
                    { 8, 1, "Hur social är du?" },
                    { 9, 1, "Hur ser du på motion?" },
                    { 10, 1, "Hur viktig är rutinen i ditt liv?" },
                    { 11, 1, "Vilken typ av sällskap föredrar du?" },
                    { 12, 1, "Vad är din inställning till städning?" },
                    { 13, 1, "Hur reagerar du på ljud och aktiviteter i ditt hem?" },
                    { 14, 1, "Vad är din syn på husdjursansvar?" },
                    { 15, 1, "Vad tycker du om att ha besök hemma?" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Content", "Rating", "ReviewedSellerId", "ReviewerId" },
                values: new object[,]
                {
                    { 1, "Great post!", 5, "user2", "user1" },
                    { 2, "Very helpful.", 4, "user1", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "ApplicationUserId", "PostId" },
                values: new object[,]
                {
                    { "user1", 1 },
                    { "user2", 2 }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionId", "Animal", "Option", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Dog", "Jag älskar att vara ute och vara aktiv", 1 },
                    { 2, "Cat", "Ligga i soffan och mysa med en bra film", 1 },
                    { 3, "Rabbit", "Läsa en bok eller pyssla i trädgården", 1 },
                    { 4, "Bird", "Organisera och dekorera hemmet", 1 },
                    { 5, "Aquarium", "Njuta av ett lugnt och stilla hem", 1 },
                    { 6, "Reptile", "Upptäcka nya intressen och hobbyer", 1 },
                    { 7, "Dog", "Ute i naturen, kanske i en park eller skog", 2 },
                    { 8, "Cat", "Inomhus, där jag kan ta det lugnt", 2 },
                    { 9, "Rabbit", "Ett tyst och stilla rum", 2 },
                    { 10, "Bird", "Ett hem fyllt med ljud och färg", 2 },
                    { 11, "Aquarium", "Ett hem som känns som ett akvarium, lugnt och fridfullt", 2 },
                    { 12, "Reptile", "I en miljö som är lite annorlunda och exotisk", 2 },
                    { 13, "Dog", "Jag gillar att spendera mycket tid utomhus och vara aktiv", 3 },
                    { 14, "Cat", "Jag vill ha sällskap men utan att behöva vara aktiv hela tiden", 3 },
                    { 15, "Rabbit", "Jag vill ha ett djur som kräver lite mindre tid och uppmärksamhet", 3 },
                    { 16, "Bird", "Jag gillar att pyssla och sköta om ett utrymme i mitt hem", 3 },
                    { 17, "Aquarium", "Jag vill ha något som är nästan självständigt", 3 },
                    { 18, "Reptile", "Jag gillar att skapa och underhålla en unik miljö", 3 },
                    { 19, "Dog", "Sport och träning", 4 },
                    { 20, "Cat", "Läsa eller titta på film", 4 },
                    { 21, "Rabbit", "Pyssla eller hantverka", 4 },
                    { 22, "Bird", "Dekorera och designa", 4 },
                    { 23, "Aquarium", "Meditation eller stilla reflektion", 4 },
                    { 24, "Reptile", "Experimentera och lära mig nya saker", 4 },
                    { 25, "Dog", "Jag går ut och rör på mig för att slappna av", 5 },
                    { 26, "Cat", "Jag myser gärna med något varmt och mjukt", 5 },
                    { 27, "Rabbit", "Jag finner lugn i att pyssla eller göra något kreativt", 5 },
                    { 28, "Bird", "Jag städar och organiserar för att rensa tankarna", 5 },
                    { 29, "Aquarium", "Jag tittar på något som ger mig frid, som fiskar som simmar", 5 },
                    { 30, "Reptile", "Jag utforskar något nytt och spännande för att distrahera mig", 5 },
                    { 31, "Dog", "Jag vill ha en kompis att spendera mycket tid med", 6 },
                    { 32, "Cat", "Jag vill ha ett djur som är självständigt men ändå socialt", 6 },
                    { 33, "Rabbit", "Jag gillar små och lugna djur som inte kräver så mycket", 6 },
                    { 34, "Bird", "Jag gillar att ta hand om och underhålla ett vackert utrymme", 6 },
                    { 35, "Aquarium", "Jag vill ha något som är lätt att sköta", 6 },
                    { 36, "Reptile", "Jag vill ha något ovanligt och lärorikt att ta hand om", 6 },
                    { 37, "Dog", "Jag är flexibel och gillar att anpassa mig", 7 },
                    { 38, "Cat", "Jag tycker om ett hem där allt har sin plats men är inte överdrivet noggrann", 7 },
                    { 39, "Rabbit", "Jag uppskattar ordning men med en touch av personlighet", 7 },
                    { 40, "Bird", "Jag älskar att ha ett perfekt organiserat och dekorerat hem", 7 },
                    { 41, "Aquarium", "Jag föredrar ett minimalistiskt och lugnt hem", 7 },
                    { 42, "Reptile", "Jag gillar att ha specifika utrymmen som är välplanerade", 7 },
                    { 43, "Dog", "Jag är mycket social och älskar att vara med andra", 8 },
                    { 44, "Cat", "Jag är social men uppskattar också min egen tid", 8 },
                    { 45, "Rabbit", "Jag gillar att vara ensam men också att ha ett lugnt sällskap ibland", 8 },
                    { 46, "Bird", "Jag tycker om att prata och interagera med andra men på mitt eget sätt", 8 },
                    { 47, "Aquarium", "Jag trivs bäst i min egen värld, men kan njuta av att titta på andra", 8 },
                    { 48, "Reptile", "Jag är mer intresserad av att observera än att delta", 8 },
                    { 49, "Dog", "Jag gillar att motionera och vara aktiv varje dag", 9 },
                    { 50, "Cat", "Jag gillar att röra mig men föredrar mer avslappnade aktiviteter", 9 },
                    { 51, "Rabbit", "Jag föredrar aktiviteter som är lugna och mindre intensiva", 9 },
                    { 52, "Bird", "Jag tycker om att ha rutiner men behöver inte mycket fysisk aktivitet", 9 },
                    { 53, "Aquarium", "Jag tycker om att sitta still och observera", 9 },
                    { 54, "Reptile", "Jag föredrar att utforska saker i min egen takt", 9 },
                    { 55, "Dog", "Rutiner är mycket viktiga för mig", 10 },
                    { 56, "Cat", "Jag gillar rutiner men kan vara flexibel när det behövs", 10 },
                    { 57, "Rabbit", "Jag uppskattar rutiner men behöver också utrymme för frihet", 10 },
                    { 58, "Bird", "Jag har vissa rutiner men är inte beroende av dem", 10 },
                    { 59, "Aquarium", "Rutiner är viktiga för mig men jag följer dem på mitt eget sätt", 10 },
                    { 60, "Reptile", "Jag föredrar att vara flexibel och följa dagsformen", 10 },
                    { 61, "Dog", "Jag föredrar ett sällskap som är lika aktivt som jag", 11 },
                    { 62, "Cat", "Jag gillar sällskap men vill också ha tid för mig själv", 11 },
                    { 63, "Rabbit", "Jag uppskattar ett lugnt och avslappnat sällskap", 11 },
                    { 64, "Bird", "Jag gillar ett sällskap som är pratsamt och uttrycksfullt", 11 },
                    { 65, "Aquarium", "Jag föredrar ett sällskap som är stillsamt och rogivande", 11 },
                    { 66, "Reptile", "Jag vill ha ett sällskap som är unikt och intressant", 11 },
                    { 67, "Dog", "Jag är noggrann med städning och gillar att ha det rent och snyggt", 12 },
                    { 68, "Cat", "Jag gillar att ha det rent men är inte överdrivet noggrann", 12 },
                    { 69, "Rabbit", "Jag uppskattar ett rent hem men tycker inte att det behöver vara perfekt", 12 },
                    { 70, "Bird", "Jag tycker om att ha ett vackert och prydligt hem", 12 },
                    { 71, "Aquarium", "Jag gillar att ha det rent och enkelt", 12 },
                    { 72, "Reptile", "Jag är mer intresserad av att ha ett intressant och organiserat utrymme", 12 },
                    { 73, "Dog", "Jag trivs bäst i ett hem med liv och rörelse", 13 },
                    { 74, "Cat", "Jag tycker om att ha det lugnt men kan stå ut med lite ljud", 13 },
                    { 75, "Rabbit", "Jag föredrar ett tyst och stilla hem", 13 },
                    { 76, "Bird", "Jag gillar att höra ljud från naturen, som fågelsång", 13 },
                    { 77, "Aquarium", "Jag föredrar en lugn och rogivande atmosfär", 13 },
                    { 78, "Reptile", "Jag gillar ett hem som är stilla men med lite variation", 13 },
                    { 79, "Dog", "Jag tar gärna på mig ansvar och trivs med det", 14 },
                    { 80, "Cat", "Jag gillar att ha ansvar men behöver också tid för mig själv", 14 },
                    { 81, "Rabbit", "Jag föredrar att ha ett ansvar som inte är för tungt", 14 },
                    { 82, "Bird", "Jag gillar att ha ansvar för att ta hand om något vackert", 14 },
                    { 83, "Aquarium", "Jag gillar att ha ansvar men på ett sätt som är enkelt och lugnt", 14 },
                    { 84, "Reptile", "Jag tar gärna på mig ansvar för något unikt och spännande", 14 },
                    { 85, "Dog", "Jag älskar att ha besök och är en utmärkt värd", 15 },
                    { 86, "Cat", "Jag gillar att ha besök men också min egen tid", 15 },
                    { 87, "Rabbit", "Jag föredrar mindre sällskap och lugna besök", 15 },
                    { 88, "Bird", "Jag gillar att dekorera och göra hemmet inbjudande för besökare", 15 },
                    { 89, "Aquarium", "Jag trivs bäst när jag kan ha mitt eget utrymme, även när jag har besök", 15 },
                    { 90, "Reptile", "Jag gillar att ha besök men vill inte att det blir för ofta", 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_PostModelId",
                table: "Bookmarks",
                column: "PostModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ApplicationUserId",
                table: "Files",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PostId",
                table: "Interests",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ApplicationUserId",
                table: "Posts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewedSellerId",
                table: "Reviews",
                column: "ReviewedSellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookmarks");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
