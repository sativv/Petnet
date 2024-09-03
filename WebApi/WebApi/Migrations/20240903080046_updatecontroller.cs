using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class updatecontroller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
