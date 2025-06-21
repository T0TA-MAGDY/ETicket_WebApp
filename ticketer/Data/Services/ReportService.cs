using Microsoft.EntityFrameworkCore;
using ticketer.ViewModels;
namespace ticketer.Data.Services

{
    public class ReportService : IReportService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ReportService> _logger;

        public ReportService(AppDbContext context, ILogger<ReportService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<MovieBookingStatsViewModel>> GetTopBookedMoviesAsync(int month, int year, int top = 5)
        {
            var result = await _context.Tickets
            .Where(t => t.IsBooked &&
                t.timing != null &&
                t.timing.Showtime != null &&
                t.timing.Showtime.Date.Month == month &&
                t.timing.Showtime.Date.Year == year)
            .Include(t => t.timing)
                .ThenInclude(ti => ti.Showtime)
                    .ThenInclude(st => st.Movie)
            .GroupBy(t => t.timing.Showtime.Movie.Name)
            .Select(g => new MovieBookingStatsViewModel
            {
                MovieTitle = g.Key,
                TicketsSold = g.Count(),
            })
            .OrderByDescending(m => m.TicketsSold)
            .Take(top)
            .ToListAsync();
            _logger.LogInformation("Top booked movies result contains {Count} item(s).", result.Count);
            return result;
        }
    }

}
