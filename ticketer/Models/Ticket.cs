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

    [ForeignKey("ShowtimeSeat")]
    public int ShowtimeSeat_Id { get; set; }

    [ForeignKey("Order")]
    public int Order_Id { get; set; }

    public ShowtimeSeat? ShowtimeSeat { get; set; }
    public TicketOrder? Order { get; set; }
    }
}