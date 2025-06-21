using ticketer.ViewModels;

namespace ticketer.Data.Services
{
    public interface IReportService
    {
        Task<List<MovieBookingStatsViewModel>> GetTopBookedMoviesAsync(int month, int year, int top = 10);
    }

}
