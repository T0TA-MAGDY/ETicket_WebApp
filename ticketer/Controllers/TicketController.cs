using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticketer.Data;
using ticketer.Models;
using Microsoft.AspNetCore.Identity;

namespace ticketer.Controllers
{
    public class TicketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TicketController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // View seats for a specific Timing
        public async Task<IActionResult> ChooseSeats(int id)
        {
            var tickets = await _context.Tickets
                .Where(t => t.Timing_Id == id)
                .ToListAsync();

            // Get the Timing details (including price)
            var timing = await _context.Timings
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (timing == null || tickets == null || tickets.Count == 0)
                return NotFound("No seats found for this timing.");

            ViewBag.Timing_Id = id;
            ViewBag.Price = timing.Price;  // Pass the price to the view
            return View(tickets);
        }

        // Book selected seats

        [HttpPost]
        public async Task<IActionResult> BookSeats(int timingId, List<int> selectedTicketIds)
        {
            if (selectedTicketIds == null || selectedTicketIds.Count == 0)
                return BadRequest("No seats selected.");

            var timing = await _context.Timings
                .Where(t => t.Id == timingId)
                .FirstOrDefaultAsync();

            if (timing == null)
                return NotFound("Invalid timing.");

            var tickets = await _context.Tickets
                .Where(t => selectedTicketIds.Contains(t.Ticket_Id) && t.Timing_Id == timingId && !t.IsBooked)
                .ToListAsync();

            if (tickets.Count != selectedTicketIds.Count)
                return BadRequest("Some seats were already booked. Please refresh and try again.");

            var userId = _userManager.GetUserId(User);
            if (userId == null)
                return Unauthorized("You must be logged in to book seats.");

            // Calculate the total price
            // Calculate total price depending on seat type
            decimal totalPrice = 0;
            foreach (var ticket in tickets)
            {
                decimal seatPrice = timing.Price;

                if (ticket.SeatType == "Premium")
                {
                    seatPrice += 50;
                }


                totalPrice += seatPrice;
            }

            // Create a new ticket order
            var order = new TicketOrder
            {
                User_Id = userId,
                Amount = tickets.Count,
                TotalPrice = totalPrice,
                PaymentStatus = "Pending",
                BookingTime = DateTime.UtcNow
            };

            _context.TicketOrders.Add(order);
            await _context.SaveChangesAsync();

            // Update the selected tickets
            foreach (var ticket in tickets)
            {
                ticket.Order_Id = order.Order_Id;
                _context.Tickets.Update(ticket);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("BookingConfirmation", new { orderId = order.Order_Id });
        }

        // Booking confirmation page
        public async Task<IActionResult> BookingConfirmation(int orderId)
        {
            var order = await _context.TicketOrders
                .Include(o => o.Tickets)
                .ThenInclude(t => t.timing)
                .ThenInclude(t => t.Showtime)
                .ThenInclude(s => s.Cinema)
                .Include(o => o.Tickets)
                .ThenInclude(t => t.timing)
                    .ThenInclude(t => t.Showtime)
                        .ThenInclude(s => s.Movie)

                .FirstOrDefaultAsync(o => o.Order_Id == orderId);

            if (order == null)
            {
                return NotFound("Order not found.");
            }

            return View(order);
        }

public async Task<IActionResult> ConfirmPaymentAndBookSeats(int orderId)
{
    var order = await _context.TicketOrders
        .Include(o => o.Tickets)
        .FirstOrDefaultAsync(o => o.Order_Id == orderId);

    if (order == null)
    {
                       return NotFound("Order not found.");

    }

    if (order.PaymentStatus != "Paid")
    {
        order.PaymentStatus = "Paid";  // Mark payment as confirmed

        foreach (var ticket in order.Tickets)
        {
            ticket.IsBooked = true;  // Book each ticket
            _context.Tickets.Update(ticket);  // Update ticket status
        }

        _context.TicketOrders.Update(order);  // Update order status
        await _context.SaveChangesAsync();  // Save changes to the database

    }

return RedirectToAction("BookingConfirmation", new { orderId = orderId });
}




    }
}
