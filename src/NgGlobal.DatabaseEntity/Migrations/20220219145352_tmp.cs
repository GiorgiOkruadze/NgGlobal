using Microsoft.EntityFrameworkCore.Migrations;

namespace NgGlobal.DatabaseEntity.Migrations
{
    public partial class tmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "cdf08e53-f0af-4f10-ad89-0658acac7f46");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "21448df4-17fa-4689-8847-bc7041274c3d");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d534e3f-09f8-43b3-9fb6-4ff58b5ec535", "AQAAAAEAACcQAAAAEIaI+l2lpChfqFgLN5/sWiRJbHIWbN3D2BCVDx+pLKAexCznxNiiNUl0cBZA/bRIng==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7304b8f1-fae1-4fd9-86e4-c1b02a9a01f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4502ff54-892f-4cbd-b8c9-9d0391f7ac28");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae8b4163-4f91-468a-b2ce-211b608a7f96", "AQAAAAEAACcQAAAAELrLX2Z04VtL2dsuuzPxydCdp8IuThyzTHRqpbIfaWmfdjr8f1CVpA1CpAiI6KQ1wA==" });
        }
    }
}
