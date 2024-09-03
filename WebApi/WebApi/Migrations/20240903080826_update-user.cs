using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class updateuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dde9325e-6c67-4257-8737-ad8fcc0143c0", "AQAAAAIAAYagAAAAEMtWzexeqKREi9JprJAdIuKcNiGaMaYNZEPh5l0/pQq3W1NjAwNy07h/RELqJUEF7g==", "ac4ae309-061e-47ec-ac95-4079d91e1da2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dbead9a-8eaa-46e6-bc10-97a485b3e700", "AQAAAAIAAYagAAAAEOeLFoTwxIwNfqf4wsVUwbfoDiCOTlSHigg0j71crd+fvC4yLiY/utxXswxzGlmkCw==", "e85e1b6f-8e9c-433a-a0a5-738d1a57a2ab" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62e10d08-a5ed-4610-8637-85513bad160c", "AQAAAAIAAYagAAAAEBlk1ec5CY16gzH4A2gHrxNjIDdoFQvWrU3UB4va+hNlAkrSllXyc9mIqsqIjq+AjQ==", "f2e461c4-cc82-44df-ae31-699e825ff8e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bb0223d-faa2-4cd7-918a-cc9403f3a779", "AQAAAAIAAYagAAAAEFSGKuxk/bv/pRIglyWzm6zTS9UhXTSEFdPvrVBrpd2Kf+n5Zh0/EHNfwidmEoJE1w==", "af660a92-39ac-4be4-931b-2064cbba3c2a" });
        }
    }
}
