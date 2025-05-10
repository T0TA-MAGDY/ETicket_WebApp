using System.ComponentModel.DataAnnotations;
using ticketer.Models;

namespace ticketer.ViewModels
{
    public class ShowtimeInputVM
    {
        [Required(ErrorMessage = "Cinema selection is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a cinema")]
        public int CinemaId { get; set; }
        public int ShowTimeId { get; set; }
        public int TimingId { get; set; }
        [Required(ErrorMessage = "Show date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today.AddDays(1); // Default to tomorrow

        [Required(ErrorMessage = "Start time is required")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; } = new TimeSpan(18, 0, 0);

        [Required(ErrorMessage = "Price is required")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}