using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestHomeServices.Infrastructure.Migrations
{
    public partial class CategoriesImagesUrlsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dde77a0b-fc30-45d2-82ea-5e3790d57d60", "AQAAAAEAACcQAAAAEJcEr/Uuo4MjSedR1yaq0Aea8p9WAhiz+HgbPsObeO3VRlRYA6u5pSqCkpKno8+L7Q==", "2002f886-e5cc-452c-82ab-c96c5379c3fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16a933b0-d824-4349-a6e2-daf6d87dad2f", "AQAAAAEAACcQAAAAEOdiWdRkar6INHFXi8Er2nsFm7TpnCmnWNKsXPNOy803TjoHmBsJeJBEsGOQhVxD0A==", "3fcdb41f-cc20-45d1-a488-1af309b3975e" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "images/electrical.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "images/plumber.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "images/handyman.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c44750a-18d1-45dc-8f6c-263770f3013b", "AQAAAAEAACcQAAAAEGDXEHypLqWQ2LbULbnS3Uiu10rPS5Sx+2z+EUNLbPzplZJlaLTiUDHqC/RyxORrpw==", "ce611e65-fc26-4c67-9b89-0c19e22107bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2836ef76-07fa-481a-b3cb-91cda684496c", "AQAAAAEAACcQAAAAEGq/nKWRuGx0JsO2Vf6RNugRSlsicYeCb8hRn5MexWjK1OSaM7JlJ3NSCj1ZsAqBvg==", "c0833ef2-fb16-4b4b-ab5b-17553865a33a" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "~/images/electrical.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "~/images/plumber.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "~/images/handyman.png");
        }
    }
}
