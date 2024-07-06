using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WisconsinGacha.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBannerCardRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Banners_BannerId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_BannerId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "BannerId",
                table: "Cards");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cards",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Cards",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Anime",
                table: "Cards",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Banners",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BannerCard",
                columns: table => new
                {
                    BannerId = table.Column<int>(type: "integer", nullable: false),
                    CardId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerCard", x => new { x.BannerId, x.CardId });
                    table.ForeignKey(
                        name: "FK_BannerCard_Banners_BannerId",
                        column: x => x.BannerId,
                        principalTable: "Banners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BannerCard_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BannerCard_CardId",
                table: "BannerCard",
                column: "CardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannerCard");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Cards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Anime",
                table: "Cards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "BannerId",
                table: "Cards",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Banners",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_BannerId",
                table: "Cards",
                column: "BannerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Banners_BannerId",
                table: "Cards",
                column: "BannerId",
                principalTable: "Banners",
                principalColumn: "Id");
        }
    }
}
