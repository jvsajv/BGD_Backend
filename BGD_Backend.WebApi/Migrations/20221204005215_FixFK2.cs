using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BGD_Backend.WebApi.Migrations
{
    public partial class FixFK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_history_Id",
                table: "items");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "items",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "history",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_history_ItemId",
                table: "history",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemId",
                table: "history",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemId",
                table: "history");

            migrationBuilder.DropIndex(
                name: "IX_history_ItemId",
                table: "history");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "history");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "items",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_items_history_Id",
                table: "items",
                column: "Id",
                principalTable: "history",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
