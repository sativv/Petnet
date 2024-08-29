using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class updatemoedls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aquarium",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bird",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cat",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dog",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rabbit",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reptile",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4e836d1-adb3-4e6a-8845-715ecb381741", "AQAAAAIAAYagAAAAEJRDPV1WDSGh2r5J3sqLPo22qrR7uupkLoJU4cdVaoS0q5ufft4nLEaahwhiMrTr6A==", "ab63ec48-32cd-44f5-9a66-e43d2b64c78a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a0d4e59-690d-45ca-a34d-c01c99ff68de", "AQAAAAIAAYagAAAAEGvrPD2RM9oIW0633uPT4Ld4Pyh7Ygnb7hHy5Fk8ahn5JOM/yXrdY7bG519dkrAngQ==", "ae479b17-3d8d-44b4-8bfd-02b412414d52" });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 1,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 2,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 3,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 4,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 5,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 6,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 7,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 8,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 9,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 10,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 11,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 12,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 13,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 14,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 15,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 16,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 17,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 18,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 19,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 20,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 21,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 22,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 23,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 24,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 25,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 26,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 27,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 28,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 29,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 30,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 31,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 32,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 33,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 34,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 35,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 36,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 37,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 38,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 39,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 40,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 41,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 42,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 43,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 44,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 45,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 46,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 47,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 48,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 49,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 50,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 51,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 52,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 53,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 54,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 55,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 56,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 57,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 58,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 59,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 60,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 61,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 62,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 63,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 64,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 65,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 66,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 67,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 68,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 69,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 70,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 71,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 72,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 73,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 74,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 75,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 76,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 77,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 78,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 79,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 80,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 81,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 82,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 83,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 84,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 85,
                column: "Animal",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 86,
                column: "Animal",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 87,
                column: "Animal",
                value: "Rabbit");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 88,
                column: "Animal",
                value: "Bird");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 89,
                column: "Animal",
                value: "Aquarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 90,
                column: "Animal",
                value: "Reptile");

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "QuizId",
                keyValue: 1,
                columns: new[] { "Aquarium", "Bird", "Cat", "Dog", "Rabbit", "Reptile" },
                values: new object[] { "Ett akvarium med fiskar kan vara en lugnande och vacker del av ditt hem. Fiskar är tysta och kräver inte mycket interaktion, men de behöver en välskött miljö för att trivas.\r\n\r\nSkötsel:\r\nSkötsel av ett akvarium innebär att regelbundet byta vatten, kontrollera vattenkvaliteten och se till att filtren fungerar korrekt. Fiskar behöver rätt typ av mat, och det är viktigt att välja fiskar som trivs tillsammans. Ett akvarium kräver också en noggrann inställning till temperatur och belysning.\r\n\r\nSaker att tänka på:\r\nFiskar är känsliga för förändringar i sin miljö, så det är viktigt att vara noggrann med vattenkvalitet och skötsel. Ett akvarium kan vara ett vackert tillskott till ditt hem, men det kräver tid och engagemang för att underhålla. Fundera på om du vill ha ett sötvatten- eller saltvattenakvarium, då de har olika krav.\r\n", "Fåglar är färgglada, intelligenta och kan vara mycket sociala. De älskar att interagera med sina ägare och vissa arter kan till och med lära sig att prata. Fåglar kräver dock mycket mental stimulans och ett tryggt hem.\r\n\r\nSkötsel:\r\nAtt ta hand om en fågel innebär att ge dem en stor, säker bur med utrymme att flyga och leka. Deras kost ska vara varierad och näringsrik, inklusive fröer, frukt och grönsaker. Fåglar behöver daglig uppmärksamhet och interaktion, samt leksaker för att hålla dem underhållna.\r\n\r\nSaker att tänka på:\r\nFåglar kan leva länge, ibland upp till flera decennier beroende på art, så det är ett långsiktigt åtagande. De kan också vara högljudda och röriga, så se till att du är beredd på detta. Det är viktigt att förstå fåglars sociala behov och att de kan bli stressade om de lämnas ensamma för länge.\r\n", "Katter är självständiga och nyfikna djur som älskar att utforska och samtidigt njuta av långa stunder av vila. De kan vara kärleksfulla och sociala, men de har också en stark egen vilja och uppskattar ofta sitt eget sällskap.\r\n\r\nSkötsel:\r\nKatter är relativt lättskötta jämfört med många andra husdjur. De behöver daglig mat, vatten, och en ren kattlåda. Katter kräver också lite lektid och mental stimulans, särskilt inomhuskatter. Regelbunden veterinärvård är också viktigt för att hålla din katt frisk.\r\n\r\nSaker att tänka på:\r\nKatter kan vara ganska självständiga, vilket gör dem idealiska för människor med hektiska scheman. Men de behöver fortfarande uppmärksamhet och omsorg. Tänk på att katter kan ha olika personligheter, från väldigt sociala till mer reserverade. Fundera på om du vill ha en inomhus- eller utomhuskatt och hur du kan göra ditt hem kattvänligt.\r\n", "Hundar är sociala, lojala och ofta fulla av energi. De är fantastiska följeslagare för dem som gillar att vara aktiva och spendera tid utomhus. Hundar kräver dagliga promenader, mental stimulans, och en hel del uppmärksamhet och kärlek.\r\n\r\nSkötsel:\r\nAtt ha en hund innebär ett stort ansvar. Förutom dagliga promenader och regelbunden motion behöver hundar också träning, socialisering, och regelbunden veterinärvård. Hundar älskar att vara en del av familjen och kräver mycket tid och engagemang från sina ägare.\r\n\r\nSaker att tänka på:\r\nInnan du skaffar en hund, tänk på att de behöver mycket tid och energi. De flesta hundar gillar inte att vara ensamma under längre perioder, så se till att din livsstil kan anpassas efter deras behov. Räkna också med kostnader för mat, veterinärbesök, försäkringar och eventuella oväntade utgifter.\r\n", "Kaniner är tysta, sällskapliga djur som trivs bäst i ett lugnt och säkert hem. De är ofta lekfulla och kan skapa starka band med sina ägare, men de är också känsliga och kräver ett särskilt omhändertagande.\r\n\r\nSkötsel:\r\nKaniner behöver en rymlig bur eller ett område där de kan röra sig fritt. Deras kost består främst av hö, grönsaker och pellets. Det är också viktigt att erbjuda dem leksaker och aktiviteter för att hålla dem mentalt stimulerade. Regelbunden rengöring av deras bur och veterinärbesök är också nödvändiga.\r\n\r\nSaker att tänka på:\r\nKaniner är känsliga djur som kräver en lugn miljö. De passar bra för personer som kan erbjuda en stabil och tyst hemmiljö. Kaniner kan leva ganska länge, så det är viktigt att vara beredd på ett långsiktigt åtagande. De är också sociala djur och kan ibland må bäst av att ha en annan kanin som sällskap.", "Reptiler är fascinerande och unika husdjur som kräver en speciell typ av skötsel. De kan vara ganska självständiga och är ofta mest lämpade för ägare som är intresserade av att skapa en specifik miljö och förstå deras unika behov.\r\n\r\nSkötsel:\r\nReptiler, såsom ormar, ödlor och sköldpaddor, kräver ett specialanpassat terrarium med rätt temperatur, belysning och luftfuktighet. Deras kost varierar beroende på art, från insekter till grönt foder. Regelbunden rengöring av terrariet och kontroll av deras miljö är avgörande för deras hälsa.\r\n\r\nSaker att tänka på:\r\nReptiler kan vara känsliga för förändringar i sin omgivning och kräver noggrann övervakning av deras livsmiljö. De är inte lika sociala som andra husdjur och kan vara mindre interaktiva, vilket är viktigt att överväga om du vill ha ett djur som du kan hantera ofta. Reptiler är bäst lämpade för dem som har ett särskilt intresse för dessa fascinerande djur och är villiga att investera tid i att skapa och underhålla deras miljö.\r\n\r\n" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aquarium",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Bird",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Cat",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Dog",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Rabbit",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Reptile",
                table: "Quizzes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d41018d8-fb36-4255-93be-5c403b90bfc4", "AQAAAAIAAYagAAAAEGppqjH8+t7MZFMi7V+rI7i8PAbvMWh9lbISyg8RU7V6Sieht0DFt+uqs76B2QJDmQ==", "94226289-f28d-4e09-9297-4fa06b5a0f4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4f8b481-df5e-4efd-a56e-df21e97745ea", "AQAAAAIAAYagAAAAEMlx8RWOB+H2fE3T3KwCdzl2OSnxvi1fcvcJaY6piczv85MS30bUTpuh1ydRSQXsiQ==", "83fb2045-9c89-404a-b6c2-b96cb0f7b277" });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 1,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 2,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 3,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 4,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 5,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 6,
                column: "Animal",
                value: "Reptil");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 7,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 8,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 9,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 10,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 11,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 12,
                column: "Animal",
                value: "Reptil");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 13,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 14,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 15,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 16,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 17,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 18,
                column: "Animal",
                value: "Reptil");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 19,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 20,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 21,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 22,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 23,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 24,
                column: "Animal",
                value: "Reptil");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 25,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 26,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 27,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 28,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 29,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 30,
                column: "Animal",
                value: "Reptil");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 31,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 32,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 33,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 34,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 35,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 36,
                column: "Animal",
                value: "Reptil");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 37,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 38,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 39,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 40,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 41,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 42,
                column: "Animal",
                value: "Reptil");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 43,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 44,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 45,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 46,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 47,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 48,
                column: "Animal",
                value: "Reptil");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 49,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 50,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 51,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 52,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 53,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 54,
                column: "Animal",
                value: "Reptil");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 55,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 56,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 57,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 58,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 59,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 60,
                column: "Animal",
                value: "Reptil");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 61,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 62,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 63,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 64,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 65,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 66,
                column: "Animal",
                value: "Reptil");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 67,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 68,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 69,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 70,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 71,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 72,
                column: "Animal",
                value: "Reptil");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 73,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 74,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 75,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 76,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 77,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 78,
                column: "Animal",
                value: "Reptil");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 79,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 80,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 81,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 82,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 83,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 84,
                column: "Animal",
                value: "Reptil");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 85,
                column: "Animal",
                value: "Hund");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 86,
                column: "Animal",
                value: "Katt");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 87,
                column: "Animal",
                value: "Kanin");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 88,
                column: "Animal",
                value: "Fågel");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 89,
                column: "Animal",
                value: "Akvarium");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 90,
                column: "Animal",
                value: "Reptil");
        }
    }
}
