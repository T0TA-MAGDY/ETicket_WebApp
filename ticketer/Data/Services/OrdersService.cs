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
            .Where(o => o.Tickets.Any()) 
            .ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(o => o.User_Id == userId).ToList();
            }

            return orders;
        }
    }
}
