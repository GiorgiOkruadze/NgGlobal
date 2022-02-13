using Microsoft.EntityFrameworkCore.Migrations;

namespace NgGlobal.DatabaseEntity.Migrations
{
    public partial class InitialDailyDataseConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_DailyDatasets_CompanyServiceLongDescriptionId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_DailyDatasets_CompanyServiceShortDescriptionId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_DailyDatasets_CompanyServiceTitleId",
                table: "Translations");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "DailyDatasets");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_DailyDatasetLongDescriptionId",
                table: "Translations",
                column: "DailyDatasetLongDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_DailyDatasetShortDescriptionId",
                table: "Translations",
                column: "DailyDatasetShortDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_DailyDatasetTitleId",
                table: "Translations",
                column: "DailyDatasetTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_DailyDatasets_DailyDatasetLongDescriptionId",
                table: "Translations",
                column: "DailyDatasetLongDescriptionId",
                principalTable: "DailyDatasets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_DailyDatasets_DailyDatasetShortDescriptionId",
                table: "Translations",
                column: "DailyDatasetShortDescriptionId",
                principalTable: "DailyDatasets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_DailyDatasets_DailyDatasetTitleId",
                table: "Translations",
                column: "DailyDatasetTitleId",
                principalTable: "DailyDatasets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_DailyDatasets_DailyDatasetLongDescriptionId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_DailyDatasets_DailyDatasetShortDescriptionId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_DailyDatasets_DailyDatasetTitleId",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_Translations_DailyDatasetLongDescriptionId",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_Translations_DailyDatasetShortDescriptionId",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_Translations_DailyDatasetTitleId",
                table: "Translations");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "DailyDatasets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_DailyDatasets_CompanyServiceLongDescriptionId",
                table: "Translations",
                column: "CompanyServiceLongDescriptionId",
                principalTable: "DailyDatasets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_DailyDatasets_CompanyServiceShortDescriptionId",
                table: "Translations",
                column: "CompanyServiceShortDescriptionId",
                principalTable: "DailyDatasets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_DailyDatasets_CompanyServiceTitleId",
                table: "Translations",
                column: "CompanyServiceTitleId",
                principalTable: "DailyDatasets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
