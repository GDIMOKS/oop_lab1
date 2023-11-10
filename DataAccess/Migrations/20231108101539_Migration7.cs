using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Migration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryCategoryId",
                table: "Categories");

            migrationBuilder.AddForeignKey(
                name: "ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ParentCategoryId",
                table: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryCategoryId",
                table: "Categories",
                column: "ParentCategoryCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }
    }
}
