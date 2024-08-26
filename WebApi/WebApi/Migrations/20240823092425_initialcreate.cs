using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
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
                name: "Quiz",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.QuizId);
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
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        name: "FK_Questions_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "QuizId",
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
                        onDelete: ReferentialAction.Restrict);
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsPrivateSeller", "IsVerified", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "QuizResult", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user1", 0, "9d3113ad-63b3-4c17-b728-b7a1d56fa7ef", "user1@example.com", false, true, true, false, null, null, null, null, null, false, null, "0169ddb7-ce00-4b23-a087-522e60b14174", false, "user1@example.com" },
                    { "user2", 0, "94ea65b9-364d-4f0c-82a7-111ccc04a8bd", "user2@example.com", false, false, false, false, null, null, null, null, null, false, null, "0ccb746f-4d0d-4418-8b21-aad6021c6cf8", false, "user2@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Quiz",
                columns: new[] { "QuizId", "Title" },
                values: new object[] { 1, "Vilket djur passar dig bäst?" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Age", "AnimalBreed", "AnimalType", "ApplicationUserId", "Description", "EarliestDelivery", "IsAdoptionReady", "Title" },
                values: new object[,]
                {
                    { 1, 2, "Labrador", "Dog", "user1", "Description for post 1", new DateOnly(2024, 9, 1), true, "Post 1" },
                    { 2, 1, "Siamese", "Cat", "user2", "Description for post 2", new DateOnly(2024, 10, 1), false, "Post 2" }
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
                    { 1, "Hund", "Jag älskar att vara ute och vara aktiv", 1 },
                    { 2, "Katt", "Ligga i soffan och mysa med en bra film", 1 },
                    { 3, "Kanin", "Läsa en bok eller pyssla i trädgården", 1 },
                    { 4, "Fågel", "Organisera och dekorera hemmet", 1 },
                    { 5, "Akvarium", "Njuta av ett lugnt och stilla hem", 1 },
                    { 6, "Reptil", "Upptäcka nya intressen och hobbyer", 1 },
                    { 7, "Hund", "Ute i naturen, kanske i en park eller skog", 2 },
                    { 8, "Katt", "Inomhus, där jag kan ta det lugnt", 2 },
                    { 9, "Kanin", "Ett tyst och stilla rum", 2 },
                    { 10, "Fågel", "Ett hem fyllt med ljud och färg", 2 },
                    { 11, "Akvarium", "Ett hem som känns som ett akvarium, lugnt och fridfullt", 2 },
                    { 12, "Reptil", "I en miljö som är lite annorlunda och exotisk", 2 },
                    { 13, "Hund", "Jag gillar att spendera mycket tid utomhus och vara aktiv", 3 },
                    { 14, "Katt", "Jag vill ha sällskap men utan att behöva vara aktiv hela tiden", 3 },
                    { 15, "Kanin", "Jag vill ha ett djur som kräver lite mindre tid och uppmärksamhet", 3 },
                    { 16, "Fågel", "Jag gillar att pyssla och sköta om ett utrymme i mitt hem", 3 },
                    { 17, "Akvarium", "Jag vill ha något som är nästan självständigt", 3 },
                    { 18, "Reptil", "Jag gillar att skapa och underhålla en unik miljö", 3 },
                    { 19, "Hund", "Sport och träning", 4 },
                    { 20, "Katt", "Läsa eller titta på film", 4 },
                    { 21, "Kanin", "Pyssla eller hantverka", 4 },
                    { 22, "Fågel", "Dekorera och designa", 4 },
                    { 23, "Akvarium", "Meditation eller stilla reflektion", 4 },
                    { 24, "Reptil", "Experimentera och lära mig nya saker", 4 },
                    { 25, "Hund", "Jag går ut och rör på mig för att slappna av", 5 },
                    { 26, "Katt", "Jag myser gärna med något varmt och mjukt", 5 },
                    { 27, "Kanin", "Jag finner lugn i att pyssla eller göra något kreativt", 5 },
                    { 28, "Fågel", "Jag städar och organiserar för att rensa tankarna", 5 },
                    { 29, "Akvarium", "Jag tittar på något som ger mig frid, som fiskar som simmar", 5 },
                    { 30, "Reptil", "Jag utforskar något nytt och spännande för att distrahera mig", 5 },
                    { 31, "Hund", "Jag vill ha en kompis att spendera mycket tid med", 6 },
                    { 32, "Katt", "Jag vill ha ett djur som är självständigt men ändå socialt", 6 },
                    { 33, "Kanin", "Jag gillar små och lugna djur som inte kräver så mycket", 6 },
                    { 34, "Fågel", "Jag gillar att ta hand om och underhålla ett vackert utrymme", 6 },
                    { 35, "Akvarium", "Jag vill ha något som är lätt att sköta", 6 },
                    { 36, "Reptil", "Jag vill ha något ovanligt och lärorikt att ta hand om", 6 },
                    { 37, "Hund", "Jag är flexibel och gillar att anpassa mig", 7 },
                    { 38, "Katt", "Jag tycker om ett hem där allt har sin plats men är inte överdrivet noggrann", 7 },
                    { 39, "Kanin", "Jag uppskattar ordning men med en touch av personlighet", 7 },
                    { 40, "Fågel", "Jag älskar att ha ett perfekt organiserat och dekorerat hem", 7 },
                    { 41, "Akvarium", "Jag föredrar ett minimalistiskt och lugnt hem", 7 },
                    { 42, "Reptil", "Jag gillar att ha specifika utrymmen som är välplanerade", 7 },
                    { 43, "Hund", "Jag är mycket social och älskar att vara med andra", 8 },
                    { 44, "Katt", "Jag är social men uppskattar också min egen tid", 8 },
                    { 45, "Kanin", "Jag gillar att vara ensam men också att ha ett lugnt sällskap ibland", 8 },
                    { 46, "Fågel", "Jag tycker om att prata och interagera med andra men på mitt eget sätt", 8 },
                    { 47, "Akvarium", "Jag trivs bäst i min egen värld, men kan njuta av att titta på andra", 8 },
                    { 48, "Reptil", "Jag är mer intresserad av att observera än att delta", 8 },
                    { 49, "Hund", "Jag gillar att motionera och vara aktiv varje dag", 9 },
                    { 50, "Katt", "Jag gillar att röra mig men föredrar mer avslappnade aktiviteter", 9 },
                    { 51, "Kanin", "Jag föredrar aktiviteter som är lugna och mindre intensiva", 9 },
                    { 52, "Fågel", "Jag tycker om att ha rutiner men behöver inte mycket fysisk aktivitet", 9 },
                    { 53, "Akvarium", "Jag tycker om att sitta still och observera", 9 },
                    { 54, "Reptil", "Jag föredrar att utforska saker i min egen takt", 9 },
                    { 55, "Hund", "Rutiner är mycket viktiga för mig", 10 },
                    { 56, "Katt", "Jag gillar rutiner men kan vara flexibel när det behövs", 10 },
                    { 57, "Kanin", "Jag uppskattar rutiner men behöver också utrymme för frihet", 10 },
                    { 58, "Fågel", "Jag har vissa rutiner men är inte beroende av dem", 10 },
                    { 59, "Akvarium", "Rutiner är viktiga för mig men jag följer dem på mitt eget sätt", 10 },
                    { 60, "Reptil", "Jag föredrar att vara flexibel och följa dagsformen", 10 },
                    { 61, "Hund", "Jag föredrar ett sällskap som är lika aktivt som jag", 11 },
                    { 62, "Katt", "Jag gillar sällskap men vill också ha tid för mig själv", 11 },
                    { 63, "Kanin", "Jag uppskattar ett lugnt och avslappnat sällskap", 11 },
                    { 64, "Fågel", "Jag gillar ett sällskap som är pratsamt och uttrycksfullt", 11 },
                    { 65, "Akvarium", "Jag föredrar ett sällskap som är stillsamt och rogivande", 11 },
                    { 66, "Reptil", "Jag vill ha ett sällskap som är unikt och intressant", 11 },
                    { 67, "Hund", "Jag är noggrann med städning och gillar att ha det rent och snyggt", 12 },
                    { 68, "Katt", "Jag gillar att ha det rent men är inte överdrivet noggrann", 12 },
                    { 69, "Kanin", "Jag uppskattar ett rent hem men tycker inte att det behöver vara perfekt", 12 },
                    { 70, "Fågel", "Jag tycker om att ha ett vackert och prydligt hem", 12 },
                    { 71, "Akvarium", "Jag gillar att ha det rent och enkelt", 12 },
                    { 72, "Reptil", "Jag är mer intresserad av att ha ett intressant och organiserat utrymme", 12 },
                    { 73, "Hund", "Jag trivs bäst i ett hem med liv och rörelse", 13 },
                    { 74, "Katt", "Jag tycker om att ha det lugnt men kan stå ut med lite ljud", 13 },
                    { 75, "Kanin", "Jag föredrar ett tyst och stilla hem", 13 },
                    { 76, "Fågel", "Jag gillar att höra ljud från naturen, som fågelsång", 13 },
                    { 77, "Akvarium", "Jag föredrar en lugn och rogivande atmosfär", 13 },
                    { 78, "Reptil", "Jag gillar ett hem som är stilla men med lite variation", 13 },
                    { 79, "Hund", "Jag tar gärna på mig ansvar och trivs med det", 14 },
                    { 80, "Katt", "Jag gillar att ha ansvar men behöver också tid för mig själv", 14 },
                    { 81, "Kanin", "Jag föredrar att ha ett ansvar som inte är för tungt", 14 },
                    { 82, "Fågel", "Jag gillar att ha ansvar för att ta hand om något vackert", 14 },
                    { 83, "Akvarium", "Jag gillar att ha ansvar men på ett sätt som är enkelt och lugnt", 14 },
                    { 84, "Reptil", "Jag tar gärna på mig ansvar för något unikt och spännande", 14 },
                    { 85, "Hund", "Jag älskar att ha besök och är en utmärkt värd", 15 },
                    { 86, "Katt", "Jag gillar att ha besök men också min egen tid", 15 },
                    { 87, "Kanin", "Jag föredrar mindre sällskap och lugna besök", 15 },
                    { 88, "Fågel", "Jag gillar att dekorera och göra hemmet inbjudande för besökare", 15 },
                    { 89, "Akvarium", "Jag trivs bäst när jag kan ha mitt eget utrymme, även när jag har besök", 15 },
                    { 90, "Reptil", "Jag gillar att ha besök men vill inte att det blir för ofta", 15 }
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
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Options");

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
                name: "Quiz");
        }
    }
}
