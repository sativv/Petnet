using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class postmodelCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Posts_PostId",
                table: "Interests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bb3e45d-b65d-46cb-8c36-819e5d9dd682", "AQAAAAIAAYagAAAAEMrzanp/WQmD1RjuXXZqiDx258hiyCBTb1Z6jri41KAUyOFJV1BgjBaa08bkrHmKEw==", "2ca45c13-5bb6-472a-9455-18b556cff8dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf30aecb-a4d6-40d2-a397-2988e5286776", "AQAAAAIAAYagAAAAEHkaY0EqJ41KDcdqx4g9zhMbeXjfrWVSKg6ZHzeQXLyazM7U+aJ7at6VoioN7pZrGg==", "6386459e-567c-4e16-a63c-2f5a63722c10" });

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Posts_PostId",
                table: "Interests",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Posts_PostId",
                table: "Interests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d545a560-b755-4516-9a24-6d9d91133cca", "AQAAAAIAAYagAAAAEHud2qhXiHHQI5+FIXO/Xr+cj5cs2g1ysvXXDPl/VOO1EDpRK2BanUhmHXEvmmmNrQ==", "431706fc-7d8b-442f-9a6f-5d1a3b3f82c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad7cc6dd-9c1b-4e77-811b-743685610bcd", "AQAAAAIAAYagAAAAELPYhmO0bsWdXX47qh73eelwYX4O8Khd8OBHO3fJ3x32JWGpxKerYCZn0GX741W3+Q==", "11f77d9f-a955-4e26-91e1-127a7945b6eb" });

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Posts_PostId",
                table: "Interests",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
