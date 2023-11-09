using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Migration11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Categories_Name",
                table: "Categories",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Authors_Name",
                table: "Authors",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Categories_Name",
                table: "Categories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Authors_Name",
                table: "Authors");
        }
    }
}
