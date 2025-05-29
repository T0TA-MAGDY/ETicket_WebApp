using System.ComponentModel.DataAnnotations.Schema;

namespace ticketer.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
    }

}