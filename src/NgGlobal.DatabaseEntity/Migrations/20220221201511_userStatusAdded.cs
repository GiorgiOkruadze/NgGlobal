using Microsoft.EntityFrameworkCore.Migrations;

namespace NgGlobal.DatabaseEntity.Migrations
{
    public partial class userStatusAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9fb50c19-b19a-4087-bf0d-f20e8e3294ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0f0f1368-5f99-4f31-860a-7eb0db401394");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f279feb7-9f8e-4454-928f-ff7ff597be22", "AQAAAAEAACcQAAAAENs9K6zugHlNu+S4CxXsRhpyPyiO2eUkaCdthC20/OtkYKJivTQcP0YPZZDgWm9LDA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1e212a34-a1f1-41c8-876b-356e4d98962b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1b08b50a-0fa7-4df2-8eac-386bbe80b1f9");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc07c773-0352-4b4a-bd0f-aa753d6f06d1", "AQAAAAEAACcQAAAAEJ1TnaRj30gtzDy6HMA2N2h46O3bdj1EQ5TBFpWCeJd0V4qqYZLy/2EVMFe8zPb1TQ==" });
        }
    }
}
