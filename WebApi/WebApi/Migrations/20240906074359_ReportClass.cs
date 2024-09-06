using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ReportClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminComment",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d4623ab-1dce-47e3-b6f4-209d15bce225", "AQAAAAIAAYagAAAAECvnaGcoV2gWvdk1cgEVSNaCehxAJitYcXfiwTxQjTDzj+lfQra4UccCD81jy6uAmQ==", "ee1b7750-0080-4134-b061-28a273d6cdf1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6d86259-4c2e-4224-98a4-e8c261ec0c61", "AQAAAAIAAYagAAAAEOqb0LBGkiUErErfYPNuNHPFAdePerBeTzPCP6dt5ZyVTDxPVoQ0xNwPjyYMrUXE/Q==", "0fc61846-870c-40a7-8c8d-1d80ac6e7483" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminComment",
                table: "Reports");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27baf54c-7725-457b-8c78-a4f002b2f9ff", "AQAAAAIAAYagAAAAEBh3aDbV9cSnVXTNiw1TIFr30gOK98l1JW7G8ZRsWQV+IWWiSdJmvDHr3jaYwzFQAg==", "eb2b7da7-bb38-484a-b5b8-99860a2361d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65f3ba02-8212-4f5d-9fc0-18324568780f", "AQAAAAIAAYagAAAAEEDL8cFhzBMF243XFGt3m8BeZQJnkXnSHFUV2DZ9ujpKfidMWJs5qV8twyMDn3xRBw==", "e8634cd9-2dcd-4432-a075-f3f43b116ffb" });
        }
    }
}
