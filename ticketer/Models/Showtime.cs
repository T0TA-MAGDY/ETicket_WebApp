using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ticketer.Models
{
    public class Showtime
    {
        [Key]
        public int Showtime_Id { get; set; }

        [Required]
        [ForeignKey("Cinema")]
        public int Cinema_Id { get; set; }

        [Required]
        [ForeignKey("Movie")]
        public int Movie_Id { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        // Non-nullable navigation properties, as Showtimes should always have a Cinema and Movie
        public Cinema Cinema { get; set; }
        public Movie Movie { get; set; }

        // Initialize collections to avoid null reference exceptions
        public ICollection<ShowtimeSeat> ShowtimeSeats { get; set; } = new List<ShowtimeSeat>();
    }
}
