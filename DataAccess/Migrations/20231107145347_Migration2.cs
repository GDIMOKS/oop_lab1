using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Songs_SongId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SongId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "CategorySong",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "integer", nullable: false),
                    SongsSongId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySong", x => new { x.CategoriesCategoryId, x.SongsSongId });
                    table.ForeignKey(
                        name: "FK_CategorySong_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySong_Songs_SongsSongId",
                        column: x => x.SongsSongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorySong_SongsSongId",
                table: "CategorySong",
                column: "SongsSongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorySong");

            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Categories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SongId",
                table: "Categories",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Songs_SongId",
                table: "Categories",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "SongId");
        }
    }
}
