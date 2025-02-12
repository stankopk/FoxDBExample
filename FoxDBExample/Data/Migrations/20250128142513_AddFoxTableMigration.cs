using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoxDBExample.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFoxTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Fox",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Fox_UserId",
                table: "Fox",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fox_AspNetUsers_UserId",
                table: "Fox",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fox_AspNetUsers_UserId",
                table: "Fox");

            migrationBuilder.DropIndex(
                name: "IX_Fox_UserId",
                table: "Fox");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Fox");
        }
    }
}
