using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class Scaffold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "+359123456789");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69383904-813c-4846-bce6-d421ce25d698", "AQAAAAEAACcQAAAAEJQKDsv+VMmlDUR02FuFWw0LoyCx4FuZ/gaXvJPPV93c+M29GBJOLvw2QfxPLA/JQA==", "867b37b5-b964-4497-bb13-9ebb95bbd397" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be054430-dacd-43e1-b0cc-85373f723f5c", "AQAAAAEAACcQAAAAEI04hfsq1X+Gi/7o9J+41i376kDZqBeCTJea9guDoGEt0hcqr+lwbSBEETWzNdjNvg==", "42de4737-296b-4eee-94a9-04eb1a8d9d8f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "+000123456789");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75e4e8e7-8414-44e9-99e9-11458a5b0bed", "AQAAAAEAACcQAAAAEIRxZRHd9gVQ0U9lLayrMK0mw7ew2mxHSNnVopVVtCXWxqh9zCuGfsrLdLhlGKys6w==", "d7d59520-fc53-43f1-bcde-61d9d6764aa5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6618a515-d20c-44ed-9088-7f24be03642b", "AQAAAAEAACcQAAAAEGSgvvZxGUg+mxlPTPellXSanaqZNAnk1lRub3SzTRJ6Q9b8feOquNST5pXv2H5xMA==", "80abb4ec-5124-4c1e-b712-79d769c56cd4" });
        }
    }
}
