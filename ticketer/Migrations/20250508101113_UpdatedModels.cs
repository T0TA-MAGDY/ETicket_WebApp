using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ticketer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_ShowtimeSeats_ShowtimeSeat_Id",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketOrders_Order_Id",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "ShowtimeSeats");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickests");

            migrationBuilder.RenameColumn(
                name: "ShowtimeSeat_Id",
                table: "Tickests",
                newName: "Timing_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_ShowtimeSeat_Id",
                table: "Tickests",
                newName: "IX_Tickests_Timing_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Order_Id",
                table: "Tickests",
                newName: "IX_Tickests_Order_Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Tickests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RowNumber",
                table: "Tickests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeatNumber",
                table: "Tickests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickests",
                table: "Tickests",
                column: "Ticket_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickests_TicketOrders_Order_Id",
                table: "Tickests",
                column: "Order_Id",
                principalTable: "TicketOrders",
                principalColumn: "Order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickests_Timings_Timing_Id",
                table: "Tickests",
                column: "Timing_Id",
                principalTable: "Timings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickests_TicketOrders_Order_Id",
                table: "Tickests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickests_Timings_Timing_Id",
                table: "Tickests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickests",
                table: "Tickests");

            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Tickests");

            migrationBuilder.DropColumn(
                name: "RowNumber",
                table: "Tickests");

            migrationBuilder.DropColumn(
                name: "SeatNumber",
                table: "Tickests");

            migrationBuilder.RenameTable(
                name: "Tickests",
                newName: "Ticket");

            migrationBuilder.RenameColumn(
                name: "Timing_Id",
                table: "Ticket",
                newName: "ShowtimeSeat_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickests_Timing_Id",
                table: "Ticket",
                newName: "IX_Ticket_ShowtimeSeat_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickests_Order_Id",
                table: "Ticket",
                newName: "IX_Ticket_Order_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Ticket_Id");

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Seat_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cinema_Id = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Seat_Id);
                    table.ForeignKey(
                        name: "FK_Seats_Cinemas_Cinema_Id",
                        column: x => x.Cinema_Id,
                        principalTable: "Cinemas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShowtimeSeats",
                columns: table => new
                {
                    ShowtimeSeats_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seat_Id1 = table.Column<int>(type: "int", nullable: true),
                    timingId = table.Column<int>(type: "int", nullable: true),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Seat_Id = table.Column<int>(type: "int", nullable: false),
                    Timing_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowtimeSeats", x => x.ShowtimeSeats_Id);
                    table.ForeignKey(
                        name: "FK_ShowtimeSeats_Seats_Seat_Id1",
                        column: x => x.Seat_Id1,
                        principalTable: "Seats",
                        principalColumn: "Seat_Id");
                    table.ForeignKey(
                        name: "FK_ShowtimeSeats_Timings_timingId",
                        column: x => x.timingId,
                        principalTable: "Timings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seats_Cinema_Id",
                table: "Seats",
                column: "Cinema_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShowtimeSeats_Seat_Id1",
                table: "ShowtimeSeats",
                column: "Seat_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_ShowtimeSeats_timingId",
                table: "ShowtimeSeats",
                column: "timingId");

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
        }
    }
}
