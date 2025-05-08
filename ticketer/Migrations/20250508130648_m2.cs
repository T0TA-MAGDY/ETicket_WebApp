using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ticketer.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "Tickests",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Tickests_Timing_Id",
                table: "Tickets",
                newName: "IX_Tickets_Timing_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickests_Order_Id",
                table: "Tickets",
                newName: "IX_Tickets_Order_Id");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Timings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SeatType",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Ticket_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketOrders_Order_Id",
                table: "Tickets",
                column: "Order_Id",
                principalTable: "TicketOrders",
                principalColumn: "Order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Timings_Timing_Id",
                table: "Tickets",
                column: "Timing_Id",
                principalTable: "Timings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketOrders_Order_Id",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Timings_Timing_Id",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Timings");

            migrationBuilder.DropColumn(
                name: "SeatType",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Tickests");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_Timing_Id",
                table: "Tickests",
                newName: "IX_Tickests_Timing_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_Order_Id",
                table: "Tickests",
                newName: "IX_Tickests_Order_Id");

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
    }
}
