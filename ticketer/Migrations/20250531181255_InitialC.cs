using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ticketer.Migrations
{
    /// <inheritdoc />
    public partial class InitialC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrders_AspNetUsers_User_Id",
                table: "TicketOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketOrders_Order_Id",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrders_AspNetUsers_User_Id",
                table: "TicketOrders",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketOrders_Order_Id",
                table: "Tickets",
                column: "Order_Id",
                principalTable: "TicketOrders",
                principalColumn: "Order_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrders_AspNetUsers_User_Id",
                table: "TicketOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketOrders_Order_Id",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrders_AspNetUsers_User_Id",
                table: "TicketOrders",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketOrders_Order_Id",
                table: "Tickets",
                column: "Order_Id",
                principalTable: "TicketOrders",
                principalColumn: "Order_Id");
        }
    }
}
