using Microsoft.EntityFrameworkCore.Migrations;

namespace NgGlobal.DatabaseEntity.Migrations
{
    public partial class changesInConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_translations_Cars_DriveTrainId",
                table: "translations");

            migrationBuilder.DropForeignKey(
                name: "FK_translations_Cars_FuelTypeId",
                table: "translations");

            migrationBuilder.DropForeignKey(
                name: "FK_translations_Cars_TransmissionId",
                table: "translations");

            migrationBuilder.DropForeignKey(
                name: "FK_translations_CompanyInfos_AddressId",
                table: "translations");

            migrationBuilder.DropForeignKey(
                name: "FK_translations_CompanyServices_CompanyServiceLongDescriptionId",
                table: "translations");

            migrationBuilder.DropForeignKey(
                name: "FK_translations_CompanyServices_CompanyServiceShortDescriptionId",
                table: "translations");

            migrationBuilder.DropForeignKey(
                name: "FK_translations_CompanyServices_CompanyServiceTitleId",
                table: "translations");

            migrationBuilder.DropForeignKey(
                name: "FK_translations_DailyDatasets_CompanyServiceLongDescriptionId",
                table: "translations");

            migrationBuilder.DropForeignKey(
                name: "FK_translations_DailyDatasets_CompanyServiceShortDescriptionId",
                table: "translations");

            migrationBuilder.DropForeignKey(
                name: "FK_translations_DailyDatasets_CompanyServiceTitleId",
                table: "translations");

            migrationBuilder.DropForeignKey(
                name: "FK_translations_Languages_LanguageId",
                table: "translations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_translations",
                table: "translations");

            migrationBuilder.RenameTable(
                name: "translations",
                newName: "Translations");

            migrationBuilder.RenameIndex(
                name: "IX_translations_TransmissionId",
                table: "Translations",
                newName: "IX_Translations_TransmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_translations_LanguageId",
                table: "Translations",
                newName: "IX_Translations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_translations_FuelTypeId",
                table: "Translations",
                newName: "IX_Translations_FuelTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_translations_DriveTrainId",
                table: "Translations",
                newName: "IX_Translations_DriveTrainId");

            migrationBuilder.RenameIndex(
                name: "IX_translations_CompanyServiceTitleId",
                table: "Translations",
                newName: "IX_Translations_CompanyServiceTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_translations_CompanyServiceShortDescriptionId",
                table: "Translations",
                newName: "IX_Translations_CompanyServiceShortDescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_translations_CompanyServiceLongDescriptionId",
                table: "Translations",
                newName: "IX_Translations_CompanyServiceLongDescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_translations_AddressId",
                table: "Translations",
                newName: "IX_Translations_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translations",
                table: "Translations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Id",
                table: "Languages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_Id",
                table: "Images",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_Id",
                table: "Contracts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Cars_DriveTrainId",
                table: "Translations",
                column: "DriveTrainId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Cars_FuelTypeId",
                table: "Translations",
                column: "FuelTypeId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Cars_TransmissionId",
                table: "Translations",
                column: "TransmissionId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_CompanyInfos_AddressId",
                table: "Translations",
                column: "AddressId",
                principalTable: "CompanyInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_CompanyServices_CompanyServiceLongDescriptionId",
                table: "Translations",
                column: "CompanyServiceLongDescriptionId",
                principalTable: "CompanyServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_CompanyServices_CompanyServiceShortDescriptionId",
                table: "Translations",
                column: "CompanyServiceShortDescriptionId",
                principalTable: "CompanyServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_CompanyServices_CompanyServiceTitleId",
                table: "Translations",
                column: "CompanyServiceTitleId",
                principalTable: "CompanyServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Languages_LanguageId",
                table: "Translations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Cars_DriveTrainId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Cars_FuelTypeId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Cars_TransmissionId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_CompanyInfos_AddressId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_CompanyServices_CompanyServiceLongDescriptionId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_CompanyServices_CompanyServiceShortDescriptionId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_CompanyServices_CompanyServiceTitleId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_DailyDatasets_CompanyServiceLongDescriptionId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_DailyDatasets_CompanyServiceShortDescriptionId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_DailyDatasets_CompanyServiceTitleId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Languages_LanguageId",
                table: "Translations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translations",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_Languages_Id",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Images_Id",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_Id",
                table: "Contracts");

            migrationBuilder.RenameTable(
                name: "Translations",
                newName: "translations");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_TransmissionId",
                table: "translations",
                newName: "IX_translations_TransmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_LanguageId",
                table: "translations",
                newName: "IX_translations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_FuelTypeId",
                table: "translations",
                newName: "IX_translations_FuelTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_DriveTrainId",
                table: "translations",
                newName: "IX_translations_DriveTrainId");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_CompanyServiceTitleId",
                table: "translations",
                newName: "IX_translations_CompanyServiceTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_CompanyServiceShortDescriptionId",
                table: "translations",
                newName: "IX_translations_CompanyServiceShortDescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_CompanyServiceLongDescriptionId",
                table: "translations",
                newName: "IX_translations_CompanyServiceLongDescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_AddressId",
                table: "translations",
                newName: "IX_translations_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_translations",
                table: "translations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_translations_Cars_DriveTrainId",
                table: "translations",
                column: "DriveTrainId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_translations_Cars_FuelTypeId",
                table: "translations",
                column: "FuelTypeId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_translations_Cars_TransmissionId",
                table: "translations",
                column: "TransmissionId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_translations_CompanyInfos_AddressId",
                table: "translations",
                column: "AddressId",
                principalTable: "CompanyInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_translations_CompanyServices_CompanyServiceLongDescriptionId",
                table: "translations",
                column: "CompanyServiceLongDescriptionId",
                principalTable: "CompanyServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_translations_CompanyServices_CompanyServiceShortDescriptionId",
                table: "translations",
                column: "CompanyServiceShortDescriptionId",
                principalTable: "CompanyServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_translations_CompanyServices_CompanyServiceTitleId",
                table: "translations",
                column: "CompanyServiceTitleId",
                principalTable: "CompanyServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_translations_DailyDatasets_CompanyServiceLongDescriptionId",
                table: "translations",
                column: "CompanyServiceLongDescriptionId",
                principalTable: "DailyDatasets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_translations_DailyDatasets_CompanyServiceShortDescriptionId",
                table: "translations",
                column: "CompanyServiceShortDescriptionId",
                principalTable: "DailyDatasets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_translations_DailyDatasets_CompanyServiceTitleId",
                table: "translations",
                column: "CompanyServiceTitleId",
                principalTable: "DailyDatasets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_translations_Languages_LanguageId",
                table: "translations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
