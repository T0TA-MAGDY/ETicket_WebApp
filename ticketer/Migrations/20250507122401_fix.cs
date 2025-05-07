using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ticketer.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Cinemas_CinemaId",
                table: "Showtimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Cinemas_Cinema_Id",
                table: "Showtimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Movies_MovieId",
                table: "Showtimes");

            migrationBuilder.DropIndex(
                name: "IX_Showtimes_CinemaId",
                table: "Showtimes");

            migrationBuilder.DropIndex(
                name: "IX_Showtimes_MovieId",
                table: "Showtimes");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Showtimes");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Showtimes");

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Cinemas_Cinema_Id",
                table: "Showtimes",
                column: "Cinema_Id",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Cinemas_Cinema_Id",
                table: "Showtimes");

            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "Showtimes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Showtimes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_CinemaId",
                table: "Showtimes",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_MovieId",
                table: "Showtimes",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Cinemas_CinemaId",
                table: "Showtimes",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Cinemas_Cinema_Id",
                table: "Showtimes",
                column: "Cinema_Id",
                principalTable: "Cinemas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Movies_MovieId",
                table: "Showtimes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
