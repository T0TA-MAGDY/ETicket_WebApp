using Microsoft.AspNetCore.Mvc.Rendering;

namespace ticketer.ViewModels
{
    public class MovieFormOptionsVM
    {
        public List<SelectListItem> Actors { get; set; } = new();
        public List<SelectListItem> Producers { get; set; } = new();
        public List<SelectListItem> Cinemas { get; set; } = new();
    }
}
