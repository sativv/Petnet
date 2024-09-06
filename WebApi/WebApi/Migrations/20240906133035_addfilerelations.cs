using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class addfilerelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e374d5e6-af6e-4f6d-9d49-4b2dd2e19248", "AQAAAAIAAYagAAAAECQV5qCNhh9Az2rw4ryCkuOydrXn6v2SU1m8bEM0R2f+dx1kLwxXi6iMMmG+kuBU2g==", "fc0c8f90-a158-4065-a35d-d6161e6c8636" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd9f864d-989e-4784-9fa7-ac332dbdf5b3", "AQAAAAIAAYagAAAAEJ3P5qi0ERKAjcZPuzBw34ZXzzznzzQWdqnX58Rf227+To4YhdaEUv+WRk5HdJ9nlQ==", "21bb03f4-70d5-4c7e-8140-909c76c8e434" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99d33ee5-7d25-40c1-bcdb-a2ac7b0578f8", "AQAAAAIAAYagAAAAEJRgR/Ky0PRGigkWfENBbqtO9Z6dWEHsNeDS3yIovXAokuo8W4d/lBmHTjyVg8ZUKg==", "17ef7b0d-3167-4aa4-b266-86c17995029e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "9e6ebc52-6c41-43f2-b60b-5ad97f71593d", "AQAAAAIAAYagAAAAEAl+DDmJwzQdbD5XnmP0ZaLWe9TFTe0QNsGbHa7gEtCvdXTpI1IurH90zC0rIonLgg==", null, "178bf747-4267-4bd5-a08d-a7c690d52934" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "e0f4f753-5c5b-49ed-8b1b-09efe5b86f96", "AQAAAAIAAYagAAAAEFJfHUitMI5NaYgQ47/s9s+n+3KrHlyeo0iXbU2zOTJn6ui2kiXhBLgCQoJIKzNjjg==", null, "a4edecef-249f-4a88-ba17-6aa3e31c745d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "109718d0-187a-4741-97dd-2b16e1b93e6d", "AQAAAAIAAYagAAAAEDRoyfr7OxCynCHdebvvx+ucZ7vWsYNRkb0owGQ2J8NzYs9WVUSeuXSa50yjyuOuFw==", null, "defa7ff6-f006-4659-b1e1-3ba0d67cb263" });
        }
    }
}
