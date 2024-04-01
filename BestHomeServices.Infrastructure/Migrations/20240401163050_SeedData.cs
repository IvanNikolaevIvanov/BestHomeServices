using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestHomeServices.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialists_Categories_CategoryId",
                table: "Specialists");

            migrationBuilder.DropTable(
                name: "CategoryCity");

            migrationBuilder.DropTable(
                name: "CitySpecialist");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Specialists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Specialist's city identifier.");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Specialists",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "User's identifier");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "a927fbbe-8eb3-4fa5-8b5c-9d1e56d4a685", "client@mail.com", false, false, null, "client@mail.com", "client@mail.com", "AQAAAAEAACcQAAAAEJsyZoTuxeED5NTbpmHNpBJUq5iKI3ZL/DGKSss/mCflwm6g7pF7q/Sm84sKCg+ulg==", null, false, "db8ca77e-1440-429e-9545-113836d59634", false, "client@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "ebc96523-b5d4-4f77-ab61-f7627d5342ef", "specialist1@mail.com", false, false, null, "specialist1@mail.com", "specialist1@mail.com", "AQAAAAEAACcQAAAAEFOzxD4JSawSFGDWhZYuTcMwJqrwST8O86H0slpw9yeVW/loirQBYZTiYkyQ9naq1Q==", null, false, "e74accf1-baeb-4b1f-9061-3e6b2d50d785", false, "specialist1@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImgUrl", "Title" },
                values: new object[,]
                {
                    { 1, "Hire one of the most experienced electricians in your area.", "~/images/electrical.png", "Electrician" },
                    { 2, "Hire one of the most experienced plumbers in your area.", "~/images/plumber.png", "Plumber" },
                    { 3, "Hire one of the most experienced handymen in your area.", "~/images/handyman.png", "Handyman" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Larnaca" },
                    { 2, null, "Pafos" },
                    { 3, null, "Limasol" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "CityId", "Name", "PhoneNumber", "UserId" },
                values: new object[] { 1, "16 Pythagorou str", 1, "Pesho Petrov", "0035799344556", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "Specialists",
                columns: new[] { "Id", "CategoryId", "CityId", "Description", "FirstName", "ImageUrl", "IsBusy", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 1, 1, 1, "This is one of the best electricians in the area.", "Ivan", "https://media.istockphoto.com/id/516005348/photo/african-electrical-worker-using-laptop-computer.jpg?s=1024x1024&w=is&k=20&c=2wnW5I1-CWTKWB2GYpmgZ5X3oA2Etvq0e_1Tn3y9T6w=", false, "Ivanov", "0012233556", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ClientId", "SpecialistId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Specialists_CityId",
                table: "Specialists",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialists_UserId",
                table: "Specialists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CategoryId",
                table: "Cities",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Categories_CategoryId",
                table: "Cities",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialists_AspNetUsers_UserId",
                table: "Specialists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialists_Categories_CategoryId",
                table: "Specialists",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialists_Cities_CityId",
                table: "Specialists",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Categories_CategoryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialists_AspNetUsers_UserId",
                table: "Specialists");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialists_Categories_CategoryId",
                table: "Specialists");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialists_Cities_CityId",
                table: "Specialists");

            migrationBuilder.DropIndex(
                name: "IX_Specialists_CityId",
                table: "Specialists");

            migrationBuilder.DropIndex(
                name: "IX_Specialists_UserId",
                table: "Specialists");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CategoryId",
                table: "Cities");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumns: new[] { "ClientId", "SpecialistId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Specialists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Specialists");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Cities");

            migrationBuilder.CreateTable(
                name: "CategoryCity",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    CitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCity", x => new { x.CategoriesId, x.CitiesId });
                    table.ForeignKey(
                        name: "FK_CategoryCity_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryCity_Cities_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitySpecialist",
                columns: table => new
                {
                    CitiesId = table.Column<int>(type: "int", nullable: false),
                    SpecialistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitySpecialist", x => new { x.CitiesId, x.SpecialistsId });
                    table.ForeignKey(
                        name: "FK_CitySpecialist_Cities_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitySpecialist_Specialists_SpecialistsId",
                        column: x => x.SpecialistsId,
                        principalTable: "Specialists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCity_CitiesId",
                table: "CategoryCity",
                column: "CitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_CitySpecialist_SpecialistsId",
                table: "CitySpecialist",
                column: "SpecialistsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialists_Categories_CategoryId",
                table: "Specialists",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
