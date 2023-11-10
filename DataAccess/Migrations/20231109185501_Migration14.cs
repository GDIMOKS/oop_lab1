using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Migration14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Collections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CategoryId",
                table: "Collections",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Categories_CategoryId",
                table: "Collections",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Categories_CategoryId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_CategoryId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Collections");
        }
    }
}
