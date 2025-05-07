using Microsoft.AspNetCore.Mvc;
using ticketer.Data;
using ticketer.Models;

namespace ticketer.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext context;

        public MovieController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Movie> movies=context.Movies.ToList();
            return View(movies);
        }
        public IActionResult Details(int id)
        {
            var movie = context.Movies.SingleOrDefault(x => x.Id == id);
            return View(movie);
        }
    }
}
