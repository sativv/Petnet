using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class imageFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Images",
                value: "[\"https://www.marthastewart.com/thmb/Ki1fnPkHDxYQv_kAN2HtBxwOELY=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/happy-labrador-retriever-getty-0322-2000-eb585d9e672e47da8b1b7e9d3215a5cb.jpg\"]");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Images",
                value: "[\"https://www.purina.co.uk/sites/default/files/styles/square_medium_440x440/public/2022-06/Siamese-Cat_0.jpg?itok=Qy1J6ZDS\"]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                column: "Images",
                value: "[\"https://www.marthastewart.com/8243168/american-kennel-club-labrador-retriever-most-popular-dog-breed-2022\"]");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Images",
                value: "[\"https://www.purina.co.uk/find-a-pet/cat-breeds/siamese\"]");
        }
    }
}
