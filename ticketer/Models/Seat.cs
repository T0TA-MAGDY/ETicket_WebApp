using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using ticketer.Data.Base;
namespace ticketer.Models
{
    public class Seat
    {
        [Key]
    public int Seat_Id { get; set; }

    [ForeignKey("Cinema")]
    public int Cinema_Id { get; set; }

    [Required]
    public string SeatNumber { get; set; }

    public string? SeatType { get; set; }

    public Cinema? Cinema { get; set; }
        public ICollection<ShowtimeSeat> ShowtimeSeats { get; set; }

    }
}