using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ticketer.Migrations
{
    /// <inheritdoc />
    public partial class AddedTimingToShowtimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowtimeSeats_Timing_timingId",
                table: "ShowtimeSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ShowtimeSeats_ShowtimeSeat_Id",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketOrders_Order_Id",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Timing_Showtimes_showtime_id",
                table: "Timing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timing",
                table: "Timing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Timing",
                newName: "Timings");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_Timing_showtime_id",
                table: "Timings",
                newName: "IX_Timings_showtime_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ShowtimeSeat_Id",
                table: "Ticket",
                newName: "IX_Ticket_ShowtimeSeat_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_Order_Id",
                table: "Ticket",
                newName: "IX_Ticket_Order_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timings",
                table: "Timings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Ticket_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowtimeSeats_Timings_timingId",
                table: "ShowtimeSeats",
                column: "timingId",
                principalTable: "Timings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_ShowtimeSeats_ShowtimeSeat_Id",
                table: "Ticket",
                column: "ShowtimeSeat_Id",
                principalTable: "ShowtimeSeats",
                principalColumn: "ShowtimeSeats_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketOrders_Order_Id",
                table: "Ticket",
                column: "Order_Id",
                principalTable: "TicketOrders",
                principalColumn: "Order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Timings_Showtimes_showtime_id",
                table: "Timings",
                column: "showtime_id",
                principalTable: "Showtimes",
                principalColumn: "Showtime_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowtimeSeats_Timings_timingId",
                table: "ShowtimeSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_ShowtimeSeats_ShowtimeSeat_Id",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketOrders_Order_Id",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Timings_Showtimes_showtime_id",
                table: "Timings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timings",
                table: "Timings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Timings",
                newName: "Timing");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Timings_showtime_id",
                table: "Timing",
                newName: "IX_Timing_showtime_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_ShowtimeSeat_Id",
                table: "Tickets",
                newName: "IX_Tickets_ShowtimeSeat_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Order_Id",
                table: "Tickets",
                newName: "IX_Tickets_Order_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timing",
                table: "Timing",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Ticket_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowtimeSeats_Timing_timingId",
                table: "ShowtimeSeats",
                column: "timingId",
                principalTable: "Timing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ShowtimeSeats_ShowtimeSeat_Id",
                table: "Tickets",
                column: "ShowtimeSeat_Id",
                principalTable: "ShowtimeSeats",
                principalColumn: "ShowtimeSeats_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketOrders_Order_Id",
                table: "Tickets",
                column: "Order_Id",
                principalTable: "TicketOrders",
                principalColumn: "Order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Timing_Showtimes_showtime_id",
                table: "Timing",
                column: "showtime_id",
                principalTable: "Showtimes",
                principalColumn: "Showtime_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
