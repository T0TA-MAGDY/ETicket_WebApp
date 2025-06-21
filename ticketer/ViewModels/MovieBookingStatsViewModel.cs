using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ticketer.ViewModels
{
    public class MovieBookingStatsViewModel
    {
        public string MovieTitle { get; set; }
        public int TicketsSold { get; set; }
    }

}
