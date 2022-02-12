using Microsoft.EntityFrameworkCore.Migrations;

namespace NgGlobal.DatabaseEntity.Migrations
{
    public partial class InitialDailyImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyServiceImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyServiceId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyServiceImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyServiceImage_CompanyServices_CompanyServiceId",
                        column: x => x.CompanyServiceId,
                        principalTable: "CompanyServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyDatasetImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyDatasetId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyDatasetImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyDatasetImage_DailyDatasets_DailyDatasetId",
                        column: x => x.DailyDatasetId,
                        principalTable: "DailyDatasets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyServiceImage_CompanyServiceId",
                table: "CompanyServiceImage",
                column: "CompanyServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyDatasetImage_DailyDatasetId",
                table: "DailyDatasetImage",
                column: "DailyDatasetId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyServiceImage");

            migrationBuilder.DropTable(
                name: "DailyDatasetImage");
        }
    }
}
