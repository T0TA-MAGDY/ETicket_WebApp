using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ticketer.Data.Base;

namespace ticketer.Models
{
    public class Review:IEntityBase
    {
        [Key]
        public int Id { get; set; }

    public int MovieId { get; set; }
    public string UserId { get; set; }
    public int Rating { get; set; } // 1 to 5
    public string? Comment  { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual Movie Movie { get; set; }
    public virtual ApplicationUser User { get; set; }
    }
}