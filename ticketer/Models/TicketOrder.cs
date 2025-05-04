using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ticketer.Models
{
    public class TicketOrder
    {
         [Key]
    public int Order_Id { get; set; }

    [ForeignKey("User")]
    public string User_Id { get; set; }

    public int Amount { get; set; }

    [DataType(DataType.Currency)]
    public decimal TotalPrice { get; set; }

    public string? PaymentStatus { get; set; }

    public DateTime BookingTime { get; set; }

    public ApplicationUser User { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

}
    }
