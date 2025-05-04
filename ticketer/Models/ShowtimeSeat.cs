using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using ticketer.Data.Base;
namespace ticketer.Models
{
    public class ShowtimeSeat
    {
         [Key]
    public int ShowtimeSeats_Id { get; set; }

    [ForeignKey("Seat")]
    public int Seat_Id { get; set; }

    [ForeignKey("Showtime")]
    public int Showtime_Id { get; set; }

    public bool IsBooked { get; set; }

    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    public Seat? Seat { get; set; }
    public Showtime? Showtime { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

    }
}