using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "OrganizationNumber",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "OrganizationNumber", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba833f92-3326-4690-8f6e-b8be0c2fd04b", 0L, "AQAAAAIAAYagAAAAEI+zYGRU9uANhyyJQbohW1dZNoe4SXArzgpOygrNFMGwTjKeGGmbbMciHFIHuFnIgg==", "b18e16f7-56c9-4ade-aef0-d2ac0242dc22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "OrganizationNumber", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02ddb803-120a-4938-9ec8-7ccdc5681abe", 0L, "AQAAAAIAAYagAAAAEJWCrtyXuqz47sakQpSV7V8H8znPj8T+aU2JQ7AruljFTu8LKEfKXei+Pl7PGe52Dg==", "1bf93b53-399b-42e6-b154-d183e8aab785" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrganizationNumber",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "OrganizationNumber", "PasswordHash", "SecurityStamp" },
                values: new object[] { "018fc2ef-2aa1-443d-a84a-a6470e984247", 0, "AQAAAAIAAYagAAAAEJggvoo5i/Kw3UUjdKl5L4TrXaB/rv1ytb8aqMTDinyQSmNWWXJWYK7a/UwaWuH2IQ==", "4d4ff0f5-9e69-475f-a169-2fe938b7b9a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "OrganizationNumber", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2cf1114-3c19-4a60-992a-1d75446b0703", 0, "AQAAAAIAAYagAAAAEG5+NmnufHwLbYLhLk/iq8WLU3xxwKLeHjvcHeoleL7S1JUpvHJAgQACWK7vBNSccg==", "c8234cb6-6bd1-4e74-894f-f4a3e0aa52ab" });
        }
    }
}
