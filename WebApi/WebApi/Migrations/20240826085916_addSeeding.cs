using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class addSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bc54ad18-cfae-4ffb-9973-e9279d5c5071", "b4247a16-9d7f-4bb5-b6f5-268598be4500" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f8870b93-2508-4f5f-9bd1-1af6c703f138", "857a4d9a-0ad7-48f2-997b-5954ef9dab4d" });

            migrationBuilder.UpdateData(
                table: "Quiz",
                keyColumn: "QuizId",
                keyValue: 1,
                column: "Info",
                value: "Välkommen till vårt husdjursquiz! Att välja rätt husdjur är ett stort beslut som bör baseras på din livsstil, personlighet och preferenser. I det här testet kommer du att besvara 15 frågor som hjälper dig att upptäcka vilket djur som passar bäst för just dig. Oavsett om du är en aktiv person som älskar att vara utomhus eller om du föredrar en lugn och stillsam miljö, så finns det ett husdjur som passar din vardag perfekt. Svara ärligt på frågorna, så får du snart veta vilken typ av husdjur som skulle bli din bästa vän!");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "Quiz");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "412a70d5-59f0-4638-8733-321246ad1bc0", "37722e1b-ead4-4754-bb4c-145781c9c3c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "20b02e04-4223-4807-ac07-d7d498342be4", "0290a5e5-7cb4-447f-826f-940c954d3c27" });
        }
    }
}
