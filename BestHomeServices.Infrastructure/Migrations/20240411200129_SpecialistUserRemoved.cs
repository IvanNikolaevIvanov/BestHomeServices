using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestHomeServices.Infrastructure.Migrations
{
    public partial class SpecialistUserRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialists_AspNetUsers_UserId",
                table: "Specialists");

            migrationBuilder.DropIndex(
                name: "IX_Specialists_UserId",
                table: "Specialists");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Specialists");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8e91d3e-671e-42e3-9c38-6bf2d2dbcea3", "AQAAAAEAACcQAAAAEG1SyzcD2fbSGb0ICTnWGnkpXtvqeAajsCRQfYTjprN8YCHpx1xra8MAymQhbqulpA==", "63b18086-8743-4067-affb-a12e84dfc814" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Specialists",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "User's identifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dde77a0b-fc30-45d2-82ea-5e3790d57d60", "AQAAAAEAACcQAAAAEJcEr/Uuo4MjSedR1yaq0Aea8p9WAhiz+HgbPsObeO3VRlRYA6u5pSqCkpKno8+L7Q==", "2002f886-e5cc-452c-82ab-c96c5379c3fe" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dea12856-c198-4129-b3f3-b893d8395082", 0, "16a933b0-d824-4349-a6e2-daf6d87dad2f", "specialist1@mail.com", false, false, null, "specialist1@mail.com", "specialist1@mail.com", "AQAAAAEAACcQAAAAEOdiWdRkar6INHFXi8Er2nsFm7TpnCmnWNKsXPNOy803TjoHmBsJeJBEsGOQhVxD0A==", null, false, "3fcdb41f-cc20-45d1-a488-1af309b3975e", false, "specialist1@mail.com" });

            migrationBuilder.UpdateData(
                table: "Specialists",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.CreateIndex(
                name: "IX_Specialists_UserId",
                table: "Specialists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialists_AspNetUsers_UserId",
                table: "Specialists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
