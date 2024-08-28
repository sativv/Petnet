using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class postModelChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Posts",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8428ddc-4977-4428-880d-354c202bb6f5", "AQAAAAIAAYagAAAAEI5l+1W4UtcFg2AfbxtrAQIXzoYFBXCwiixXfno3s04an4y6wOiao2S4tDjFFVSYIg==", "382160b9-9d1f-472e-91e0-05f96d114978" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "248fd294-b541-40be-b759-c5a34762a037", "AQAAAAIAAYagAAAAEEAn6ONOmquYIeiwpLfbfnGJSD2OW5oapprGQV8axSDZQZ8u+/KKRRVYFJ1Vs3hHNg==", "c32c325b-cfb4-41b0-99cd-940b05775d1c" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Gender", "Images" },
                values: new object[] { new DateOnly(2020, 11, 1), "Male", "[\"https://www.marthastewart.com/8243168/american-kennel-club-labrador-retriever-most-popular-dog-breed-2022\"]" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "Gender", "Images" },
                values: new object[] { new DateOnly(2021, 11, 1), "Female", "[\"https://www.purina.co.uk/find-a-pet/cat-breeds/siamese\"]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dae4332-ef96-4e07-b5e0-81447ef33d83", "AQAAAAIAAYagAAAAEATVsgv76GBq5kd5y01U8EXpOAv0Ayi7EU5kSasdkshXhXylcVvUtsq5Anpn8jQjxA==", "23475818-f242-4f2d-ae5f-df97f1371d14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcea9183-542b-4c78-b44f-ec6148f0d995", "AQAAAAIAAYagAAAAEL1qMPpgmM0LtvUkVUhmsIMH1bFJbHLw5mJ2q0cuLD7WIyFiTYk8kPIP5xSr/UBTBA==", "c13f2776-d1a3-4213-85e9-a4b8a22b3b5c" });
        }
    }
}
