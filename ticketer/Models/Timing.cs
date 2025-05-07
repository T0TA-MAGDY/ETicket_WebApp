using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ticketer.Models
{
    public class Timing
    {
        public int Id { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        public int showtime_id { get; set; }

        [ForeignKey("showtime_id")]
        public Showtime Showtime { get; set; }

        public ICollection<ShowtimeSeat> ShowtimeSeats { get; set; } = new List<ShowtimeSeat>();
    }
}
