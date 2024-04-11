using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestHomeServices.Infrastructure.Migrations
{
    public partial class MoreSpecialistsSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ef3c88d-226e-4b42-941b-69c937b207bb", "AQAAAAEAACcQAAAAEEEkPG9xLkrBbrSVkcG7ke/MgdpKu9XO8a5ohZYhzuEpeF+a/1sL+6htOOa7/hcxSA==", "778489e1-d3e9-4267-8794-e5538e890bbb" });

            migrationBuilder.InsertData(
                table: "Specialists",
                columns: new[] { "Id", "CategoryId", "CityId", "Description", "FirstName", "ImageUrl", "IsBusy", "LastName", "PhoneNumber" },
                values: new object[] { 2, 2, 1, "This is one of the best plumbers in the area.", "Pesho", "https://degraceplumbing.com/wp-content/uploads/2016/02/NJ-plumber-300x200.jpg", false, "Peshev", "0012233559" });

            migrationBuilder.InsertData(
                table: "Specialists",
                columns: new[] { "Id", "CategoryId", "CityId", "Description", "FirstName", "ImageUrl", "IsBusy", "LastName", "PhoneNumber" },
                values: new object[] { 3, 3, 2, "This is one of the best handymen in the area.", "Stefka", "https://image1.masterfile.com/getImage/NjAwLTA2NjcxNzUwZW4uMDAwMDAwMDA=AKvV1Y/600-06671750en_Masterfile.jpg", false, "Zlateva", "0012233552" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8e91d3e-671e-42e3-9c38-6bf2d2dbcea3", "AQAAAAEAACcQAAAAEG1SyzcD2fbSGb0ICTnWGnkpXtvqeAajsCRQfYTjprN8YCHpx1xra8MAymQhbqulpA==", "63b18086-8743-4067-affb-a12e84dfc814" });
        }
    }
}
