using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAccountApp.Data.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MyUserId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MyUserId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f62dcf96-bd46-4aa9-a273-afb40646c98a", 0, "7181a472-5ae9-4096-ac2c-41615b790f94", "guest@mail.com", false, "Fname", "Lname", false, null, 0, "GUEST@MAIL.COM", "GUESTNAME", "AQAAAAEAACcQAAAAEONAYLS7jtDjEZeBoFOxXrT7lUTzcjdQXnJvxoCYILYijPTpxIB7MCJxDlxhhP3gVA==", null, false, "6c7ca24d-aa64-41cf-a50b-8a23fe712021", false, "GuestName" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 3, 17, 5, 45, 176, DateTimeKind.Utc).AddTicks(9366), "Learn ASP.NET Core Identity", "f62dcf96-bd46-4aa9-a273-afb40646c98a", "Prepare for ASP.NET Core Fundamentals Exam" },
                    { 2, 1, new DateTime(2022, 6, 3, 17, 5, 45, 176, DateTimeKind.Utc).AddTicks(9384), "Learn using EF Core and MS SQL Server Managment Studio", "f62dcf96-bd46-4aa9-a273-afb40646c98a", "Improve EF Core skills" },
                    { 3, 1, new DateTime(2022, 10, 24, 17, 5, 45, 176, DateTimeKind.Utc).AddTicks(9388), "Learn using ASP.NET Core Identity", "f62dcf96-bd46-4aa9-a273-afb40646c98a", "Improve ASP.NET Core skills" },
                    { 4, 1, new DateTime(2022, 6, 3, 17, 5, 45, 176, DateTimeKind.Utc).AddTicks(9410), "Prepare by solving old Mid and Final Exams", "f62dcf96-bd46-4aa9-a273-afb40646c98a", "Prepare for C# Fundamentals Exam" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f62dcf96-bd46-4aa9-a273-afb40646c98a");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MyUserId",
                table: "AspNetUsers");
        }
    }
}
