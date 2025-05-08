using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ticketer.Models
{
    public class Timing
    {
        public int Id { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }
        [ForeignKey("showtime_id")]
        public int showtime_id { get; set; }

        public Showtime Showtime { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
