using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BGD_Backend.WebApi.Data.Migrations
{
    public partial class ItemInHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "history",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_history_ItemId",
                table: "history",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_history_items_ItemId",
                table: "history",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_history_items_ItemId",
                table: "history");

            migrationBuilder.DropIndex(
                name: "IX_history_ItemId",
                table: "history");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "history");
        }
    }
}
