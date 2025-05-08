using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ticketer.Models
{
    public class Ticket
    {
        [Key]
        public int Ticket_Id { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public int Timing_Id { get; set; }
        public Timing? timing { get; set; }
        public bool IsBooked { get; set; } = false;

        public string SeatType { get; set; }  // "Regular" or "Premium"

        [ForeignKey("Order")]
        public int? Order_Id { get; set; }

        public TicketOrder? Order { get; set; }
    }
}