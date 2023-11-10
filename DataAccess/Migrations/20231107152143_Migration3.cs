using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "Categories",
                newName: "ParentCategoryIdCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryIdCategoryId",
                table: "Categories",
                column: "ParentCategoryIdCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryIdCategoryId",
                table: "Categories",
                column: "ParentCategoryIdCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryIdCategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentCategoryIdCategoryId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryIdCategoryId",
                table: "Categories",
                newName: "ParentCategoryId");
        }
    }
}
