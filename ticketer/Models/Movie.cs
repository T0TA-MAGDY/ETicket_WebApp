using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ticketer.Data.Base;
using System.ComponentModel.DataAnnotations;
using ticketer.Data;
using System.ComponentModel.DataAnnotations.Schema;
using ticketer.Data.Enums;
namespace ticketer.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required] // Mark as required
        public string Name { get; set; }

        [Required] // Mark as required
        public string Description { get; set; }



        [Required] // Mark as required
        public string ImageURL { get; set; }

        [DataType(DataType.Date)]
        [Required] // Mark as required
        public DateTime ReleaseDate { get; set; }

        public string TrailerURL { get; set; }

        [Required] // Mark as required
        public MovieCategory MovieCategory { get; set; }

        // Relationships


        // Producer
        [Required] // Assuming every movie must have a producer
        public int ProducerId { get; set; }

        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

        // Many-to-many relationship with Actor
        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();

        // Many-to-one relationship with Showtime
        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
        public virtual ICollection<Review> Reviews { get; set; }

    }
}
