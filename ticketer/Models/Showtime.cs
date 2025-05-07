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
        public int Cinema_Id { get; set; }

        public int Movie_Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public Cinema Cinema { get; set; }
        public Movie Movie { get; set; }

        
       
        public ICollection<Timing> Timing { get; set; }
    }
}
