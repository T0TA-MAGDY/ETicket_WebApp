using ticketer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ticketer.Data.Services
{
    public interface IOrdersService
    {
        Task<List<TicketOrder>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
