using Microsoft.EntityFrameworkCore.Migrations;

namespace NgGlobal.DatabaseEntity.Migrations
{
    public partial class initialUserStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

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
    }
}
