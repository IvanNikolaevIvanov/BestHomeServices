using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestHomeServices.Infrastructure.Migrations
{
    public partial class AdminUserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8054ec4-5400-4ec6-aa54-9a98016370a8", true, "CLIENT@MAIL.COM", "CLIENT@MAIL.COM", "AQAAAAEAACcQAAAAEFeBKd1yGkJ30LNXE03RplzikkJCj95KB8lPzsGxGyknc72glFtc+j7LI9+lGnAhjA==", "23219567-6bcc-4fae-9eea-119e0b471a88" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c5b3928f-781a-4d2b-88c5-c6a10572e32b", 0, "b532a45b-bcaf-4a03-95b7-2a1668d34174", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAECklVjPqAknxYWs+mv9XNO1Xmlrfekx09dD9onSF7noRXHfhxePBZfPJbkwN+a1tjg==", null, false, "2af3a071-5ebc-4656-858f-690656b85c6f", false, "admin@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5b3928f-781a-4d2b-88c5-c6a10572e32b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ef3c88d-226e-4b42-941b-69c937b207bb", false, "client@mail.com", "client@mail.com", "AQAAAAEAACcQAAAAEEEkPG9xLkrBbrSVkcG7ke/MgdpKu9XO8a5ohZYhzuEpeF+a/1sL+6htOOa7/hcxSA==", "778489e1-d3e9-4267-8794-e5538e890bbb" });
        }
    }
}
