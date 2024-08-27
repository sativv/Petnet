using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitilCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "08da5993-5ea1-46c6-9f38-88cef453ce15", "dfc299b3-798f-46f6-bc81-3b6e469be5e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "df20386d-0eff-44aa-ac8a-058483bf1f2a", "45a98cee-121a-4af7-bbb6-1b556708c756" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9d3113ad-63b3-4c17-b728-b7a1d56fa7ef", "0169ddb7-ce00-4b23-a087-522e60b14174" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "94ea65b9-364d-4f0c-82a7-111ccc04a8bd", "0ccb746f-4d0d-4418-8b21-aad6021c6cf8" });
        }
    }
}
