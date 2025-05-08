using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ticketer.Data.Base;
using System.Threading.Tasks;

namespace ticketer.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema name is required")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Cinema Address is required")]
        public string Address { get; set; }

        // Initialize collections to avoid null references
        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
