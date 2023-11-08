using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategorySong_Categories_CategoriesCategoryId",
                table: "CategorySong");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorySong_Songs_SongsSongId",
                table: "CategorySong");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionSong_Collections_CollectionsCollectionId",
                table: "CollectionSong");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionSong_Songs_SongsSongId",
                table: "CollectionSong");

            migrationBuilder.RenameColumn(
                name: "SongsSongId",
                table: "CollectionSong",
                newName: "SongsId");

            migrationBuilder.RenameColumn(
                name: "CollectionsCollectionId",
                table: "CollectionSong",
                newName: "CollectionsId");

            migrationBuilder.RenameIndex(
                name: "IX_CollectionSong_SongsSongId",
                table: "CollectionSong",
                newName: "IX_CollectionSong_SongsId");

            migrationBuilder.RenameColumn(
                name: "SongsSongId",
                table: "CategorySong",
                newName: "SongsId");

            migrationBuilder.RenameColumn(
                name: "CategoriesCategoryId",
                table: "CategorySong",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_CategorySong_SongsSongId",
                table: "CategorySong",
                newName: "IX_CategorySong_SongsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Collections",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySong_Categories_SongsId",
                table: "CategorySong",
                column: "SongsId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySong_Songs_CategoriesId",
                table: "CategorySong",
                column: "CategoriesId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionSong_Collections_SongsId",
                table: "CollectionSong",
                column: "SongsId",
                principalTable: "Collections",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionSong_Songs_CollectionsId",
                table: "CollectionSong",
                column: "CollectionsId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategorySong_Categories_SongsId",
                table: "CategorySong");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorySong_Songs_CategoriesId",
                table: "CategorySong");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionSong_Collections_SongsId",
                table: "CollectionSong");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionSong_Songs_CollectionsId",
                table: "CollectionSong");

            migrationBuilder.RenameColumn(
                name: "SongsId",
                table: "CollectionSong",
                newName: "SongsSongId");

            migrationBuilder.RenameColumn(
                name: "CollectionsId",
                table: "CollectionSong",
                newName: "CollectionsCollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_CollectionSong_SongsId",
                table: "CollectionSong",
                newName: "IX_CollectionSong_SongsSongId");

            migrationBuilder.RenameColumn(
                name: "SongsId",
                table: "CategorySong",
                newName: "SongsSongId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "CategorySong",
                newName: "CategoriesCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategorySong_SongsId",
                table: "CategorySong",
                newName: "IX_CategorySong_SongsSongId");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Collections",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySong_Categories_CategoriesCategoryId",
                table: "CategorySong",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySong_Songs_SongsSongId",
                table: "CategorySong",
                column: "SongsSongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionSong_Collections_CollectionsCollectionId",
                table: "CollectionSong",
                column: "CollectionsCollectionId",
                principalTable: "Collections",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionSong_Songs_SongsSongId",
                table: "CollectionSong",
                column: "SongsSongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
