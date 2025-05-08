using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticketer.Data;
using ticketer.Models;

namespace ticketer.Controllers
{
    public class TimingController : Controller
    {
        private readonly AppDbContext _context;

        public TimingController(AppDbContext context)
        {
            _context = context;
        }

        // Show list of timings
        public async Task<IActionResult> Index()
        {
            var timings = await _context.Timings
                .Include(t => t.Showtime)
                .ThenInclude(s => s.Movie)
                .Include(t => t.Showtime)
                .ThenInclude(s => s.Cinema)
                .ToListAsync();

            return View(timings);
        }

        // Create Timing (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Create Timing (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Timing timing)
        {
            if (ModelState.IsValid)
            {
                _context.Timings.Add(timing);
                await _context.SaveChangesAsync();

                // After saving Timing, create tickets
                await CreateTicketsForTiming(timing.Id);

                return RedirectToAction(nameof(Index));
            }
            return View(timing);
        }

        // Method to create seats automatically
        private async Task CreateTicketsForTiming(int timingId)
        {
            var tickets = new List<Ticket>();

            for (int row = 1; row <= 10; row++) // 10 rows
            {
                for (int seat = 1; seat <= 15; seat++) // 15 seats per row
                {
                    var ticket = new Ticket
                    {
                        Timing_Id = timingId,
                        RowNumber = row,
                        SeatNumber = seat,
                        SeatType = (row <= 2) ? "Premium" : "Regular", // First 2 rows Premium
                        IsBooked = false
                    };
                    tickets.Add(ticket);
                }
            }

            await _context.Tickets.AddRangeAsync(tickets);
            await _context.SaveChangesAsync();
        }
    }
}
