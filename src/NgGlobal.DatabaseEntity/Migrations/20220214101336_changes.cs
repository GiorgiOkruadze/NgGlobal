using Microsoft.EntityFrameworkCore.Migrations;

namespace NgGlobal.DatabaseEntity.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "CompanyServices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "CompanyServices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
