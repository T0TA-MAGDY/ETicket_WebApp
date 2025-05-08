using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using ticketer.Data.Enums;

namespace ticketer.ViewModels
{

    public class MovieViewModel
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "The Image URL field is required.")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "The Trailer URL field is required.")]
        public string TrailerURL { get; set; }

        [Required(ErrorMessage = "The Release Date field is required.")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "The Category field is required.")]
        public MovieCategory MovieCategory { get; set; }

        // Relationships
        [Required(ErrorMessage = "The Producers field is required.")]
        public int ProducerId { get; set; }

        [Required(ErrorMessage = "The Actors field is required.")]
        public List<int> ActorIds { get; set; } = new();

        [Required(ErrorMessage = "At least one showtime is required.")]
        public List<ShowtimeInputVM> Showtimes { get; set; } = new();

        public MovieFormOptionsVM FormOptions { get; set; } = new();
    }
}

    
    



