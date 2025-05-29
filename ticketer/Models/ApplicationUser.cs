using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace ticketer.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Display(Name = "Full name")]
        public string FullName { get; set; } = "Rasha";
        public ICollection<TicketOrder> TicketOrders { get; set; } = new List<TicketOrder>();
           public virtual ICollection<Review> Reviews { get; set; }


    }
   
}