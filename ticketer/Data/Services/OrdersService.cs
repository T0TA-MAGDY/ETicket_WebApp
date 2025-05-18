using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ticketer.Models;

namespace ticketer.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TicketOrder>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.TicketOrders
                .Include(o => o.Tickets)
                    .ThenInclude(t => t.timing)
                        .ThenInclude(tm => tm.Showtime)
                            .ThenInclude(st => st.Movie)
                .Include(o => o.User)
                .ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(o => o.User_Id == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<int> timingIds, List<int> seatIds, string userId, string userEmailAddress)
        {
            if (timingIds == null || seatIds == null || timingIds.Count != seatIds.Count)
                throw new ArgumentException("TimingIds and SeatIds must be non-null and of the same length.");

            // Fetch the timings (to get prices)
            var timings = await _context.Timings
                .Where(t => timingIds.Contains(t.Id))
                .ToListAsync();

            // Calculate total price
            decimal totalPrice = timings.Sum(t => t.Price);

            var order = new TicketOrder
            {
                User_Id = userId,
                BookingTime = DateTime.Now,
                PaymentStatus = "Pending",
                TotalPrice = totalPrice,
                Amount = timingIds.Count
            };

            await _context.TicketOrders.AddAsync(order);
            await _context.SaveChangesAsync();

            // Create tickets linked to this order
            for (int i = 0; i < timingIds.Count; i++)
            {
                var ticket = new Ticket
                {
                    Timing_Id = timingIds[i],
                    Order_Id = order.Order_Id,
                    // If you have Seat_Id property on Ticket, add it here:
                    // Seat_Id = seatIds[i]
                };

                await _context.Tickets.AddAsync(ticket);
            }

            await _context.SaveChangesAsync();
        }
    }
}
