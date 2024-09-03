using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class nullableregister : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "544d7475-a8d2-4888-8a64-25dac3877f92", "AQAAAAIAAYagAAAAELKsEkyThfJHhDc+fh2wksqhl0EnMKbzkP3HxeJHsiYS4ytOG2n3vKKU+9aJwWkjWA==", "f94dadff-f609-443d-a3ed-e0b06fea6ef4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ee87803-e83b-4460-a66e-cf43dd00be2d", "AQAAAAIAAYagAAAAEB5p4cBKZLkZ55wrPRba4d2/E4Y9rPWqoPQcK4j7I+RkGf9jr89rTbK8+KMwDkUxVQ==", "24cacea2-3ba9-48e4-bf00-bc1dcf9da3a5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0b8b021-b53c-4347-b310-73e378e294ae", "AQAAAAIAAYagAAAAEIQCu9yRM6tfCRfg3Y5G3S8zAZ8gIzoKVl9+ZmfgWxAKcI8WOBEbLBfgtgGOKD2pJQ==", "0689a2fa-b56e-4f74-9b40-0052ca7cb7de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "784d3d2a-2360-4ee4-9d11-c428b588d002", "AQAAAAIAAYagAAAAEPG3uqagbdOdm26GZaB+BoDxt1ZrKpuMQWYLtvpAgkPqFds3gERscgX8eL0nXVEZyA==", "46d7629e-57d2-4ad8-8153-5a670e05f7fb" });
        }
    }
}
