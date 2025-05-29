using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using ticketer.Data;
using ticketer.Models;
using System;

namespace ticketer.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int movieId, int rating, string comment)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var review = new Review
            {
                MovieId = movieId,
                UserId = userId, // use string for identity user IDs
                Rating = rating,
                Comment = comment,
                CreatedAt = DateTime.Now
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return RedirectToAction("ShowDetails", "Movie", new { id = movieId });
        }
    }
}
