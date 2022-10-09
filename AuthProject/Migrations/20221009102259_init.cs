using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "varchar(10)", nullable: false),
                    Password = table.Column<string>(type: "varchar(10)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0f7aa8ed-f39c-45a7-b0a7-0362c4f40ff4"), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f7ac39b4-b3b6-41c6-8c26-b774e37ba568"), "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("22dedf88-c3df-41c5-a4b7-3918e788bbcf"), "Admin@123", new Guid("0f7aa8ed-f39c-45a7-b0a7-0362c4f40ff4"), "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("87eb8360-482a-4708-948d-9f8749c98163"), "User@123", new Guid("f7ac39b4-b3b6-41c6-8c26-b774e37ba568"), "User" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
