using Microsoft.EntityFrameworkCore.Migrations;

namespace NgGlobal.DatabaseEntity.Migrations
{
    public partial class carModelPropertyChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manufacture",
                table: "Cars",
                newName: "Manufacturer");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Cars",
                newName: "Manufacture");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a9bb1054-6004-48fb-8c27-a8b469f739a4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ca71f879-b40e-4448-98e8-30d1f2a918d9");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd98010b-266f-4f31-b725-a1c87cfcb345", "AQAAAAEAACcQAAAAEIU5LCMzhMZ39wnaOgLqRpRMW9Xz+0ctRmXoXRXK3Ull92OGREgKXaUIo9fQ0hIGdQ==" });
        }
    }
}
