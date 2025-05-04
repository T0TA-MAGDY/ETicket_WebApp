using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ticketer.Data.Base;
namespace ticketer.Models
{
    public class MovieActor
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    public string? RoleName { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}