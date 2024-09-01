using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class updateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrganizationName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "OrganizationName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0b8b021-b53c-4347-b310-73e378e294ae", null, "AQAAAAIAAYagAAAAEIQCu9yRM6tfCRfg3Y5G3S8zAZ8gIzoKVl9+ZmfgWxAKcI8WOBEbLBfgtgGOKD2pJQ==", "0689a2fa-b56e-4f74-9b40-0052ca7cb7de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "OrganizationName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "784d3d2a-2360-4ee4-9d11-c428b588d002", null, "AQAAAAIAAYagAAAAEPG3uqagbdOdm26GZaB+BoDxt1ZrKpuMQWYLtvpAgkPqFds3gERscgX8eL0nXVEZyA==", "46d7629e-57d2-4ad8-8153-5a670e05f7fb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrganizationName",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "OrganizationName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba833f92-3326-4690-8f6e-b8be0c2fd04b", 0, "AQAAAAIAAYagAAAAEI+zYGRU9uANhyyJQbohW1dZNoe4SXArzgpOygrNFMGwTjKeGGmbbMciHFIHuFnIgg==", "b18e16f7-56c9-4ade-aef0-d2ac0242dc22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "OrganizationName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02ddb803-120a-4938-9ec8-7ccdc5681abe", 0, "AQAAAAIAAYagAAAAEJWCrtyXuqz47sakQpSV7V8H8znPj8T+aU2JQ7AruljFTu8LKEfKXei+Pl7PGe52Dg==", "1bf93b53-399b-42e6-b154-d183e8aab785" });
        }
    }
}
