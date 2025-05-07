using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ticketer.Migrations
{
    /// <inheritdoc />
    public partial class fixdublicate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowtimeSeats_Seats_Seat_Id",
                table: "ShowtimeSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowtimeSeats_Showtimes_Showtime_Id",
                table: "ShowtimeSeats");

            migrationBuilder.DropIndex(
                name: "IX_ShowtimeSeats_Seat_Id",
                table: "ShowtimeSeats");

            migrationBuilder.DropIndex(
                name: "IX_ShowtimeSeats_Showtime_Id",
                table: "ShowtimeSeats");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Showtimes");

            migrationBuilder.RenameColumn(
                name: "Showtime_Id",
                table: "ShowtimeSeats",
                newName: "Timing_Id");

            migrationBuilder.AddColumn<int>(
                name: "Seat_Id1",
                table: "ShowtimeSeats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "timingId",
                table: "ShowtimeSeats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Timing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    showtime_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timing_Showtimes_showtime_id",
                        column: x => x.showtime_id,
                        principalTable: "Showtimes",
                        principalColumn: "Showtime_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShowtimeSeats_Seat_Id1",
                table: "ShowtimeSeats",
                column: "Seat_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_ShowtimeSeats_timingId",
                table: "ShowtimeSeats",
                column: "timingId");

            migrationBuilder.CreateIndex(
                name: "IX_Timing_showtime_id",
                table: "Timing",
                column: "showtime_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowtimeSeats_Seats_Seat_Id1",
                table: "ShowtimeSeats",
                column: "Seat_Id1",
                principalTable: "Seats",
                principalColumn: "Seat_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowtimeSeats_Timing_timingId",
                table: "ShowtimeSeats",
                column: "timingId",
                principalTable: "Timing",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowtimeSeats_Seats_Seat_Id1",
                table: "ShowtimeSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowtimeSeats_Timing_timingId",
                table: "ShowtimeSeats");

            migrationBuilder.DropTable(
                name: "Timing");

            migrationBuilder.DropIndex(
                name: "IX_ShowtimeSeats_Seat_Id1",
                table: "ShowtimeSeats");

            migrationBuilder.DropIndex(
                name: "IX_ShowtimeSeats_timingId",
                table: "ShowtimeSeats");

            migrationBuilder.DropColumn(
                name: "Seat_Id1",
                table: "ShowtimeSeats");

            migrationBuilder.DropColumn(
                name: "timingId",
                table: "ShowtimeSeats");

            migrationBuilder.RenameColumn(
                name: "Timing_Id",
                table: "ShowtimeSeats",
                newName: "Showtime_Id");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Showtimes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_ShowtimeSeats_Seat_Id",
                table: "ShowtimeSeats",
                column: "Seat_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShowtimeSeats_Showtime_Id",
                table: "ShowtimeSeats",
                column: "Showtime_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowtimeSeats_Seats_Seat_Id",
                table: "ShowtimeSeats",
                column: "Seat_Id",
                principalTable: "Seats",
                principalColumn: "Seat_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowtimeSeats_Showtimes_Showtime_Id",
                table: "ShowtimeSeats",
                column: "Showtime_Id",
                principalTable: "Showtimes",
                principalColumn: "Showtime_Id");
        }
    }
}
