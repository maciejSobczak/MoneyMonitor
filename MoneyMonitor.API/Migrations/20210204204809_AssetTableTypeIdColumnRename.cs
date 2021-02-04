using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyMonitor.API.Migrations
{
    public partial class AssetTableTypeIdColumnRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetTypes_AssetTypeId",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "AssetTypeId",
                table: "Assets",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_AssetTypeId",
                table: "Assets",
                newName: "IX_Assets_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssetTypes_TypeId",
                table: "Assets",
                column: "TypeId",
                principalTable: "AssetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetTypes_TypeId",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Assets",
                newName: "AssetTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_TypeId",
                table: "Assets",
                newName: "IX_Assets_AssetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssetTypes_AssetTypeId",
                table: "Assets",
                column: "AssetTypeId",
                principalTable: "AssetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
