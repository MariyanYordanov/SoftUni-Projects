using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class HousesIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "96e48a32-f9c4-4301-a354-26d21f6d37c0", "AQAAAAEAACcQAAAAEBbxdiAXR9zxnEah6q1phazQb+e2uq73h9937QDoZnYN2THLk7vtaeQTjKG2fyNaTA==", "ba651c2c-2de0-4029-b51c-6c16d21e0181" });

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "8e133451-8e7d-487e-96f4-b4bc57735b8e", "AQAAAAEAACcQAAAAEE0nqp4ZL1YCVlUmByTLkpu61VfvKGbcSAzjCo8FxhmIju3YkDtUKKCjAedxAfheaA==", "4cbecc02-0444-4119-b942-e633be2234de" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1388fa40-29c9-4071-bcfd-e34f58bcd671", "AQAAAAEAACcQAAAAEMI4/8uYUx/SYR36guMnJcEd8nJ8ai4fFm0dTEDmwBbBQvR+kNxFsebOC5JsJ1S/sA==", "53196848-9399-4f98-bfe0-bd2d794d3bbd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bba62d3a-dc85-44cd-b46c-757426f68c56", "AQAAAAEAACcQAAAAEPtlhnThQjIxqZnWy10YYfJbK/paZFEqIpGnUK3RwJkeDqz377AUqqfdvB2Qc9TcHg==", "e4325036-93d8-4a92-ab9d-dbd8ce1b03d0" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: true);
        }
    }
}
