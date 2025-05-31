using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
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
         private readonly UserManager<ApplicationUser> _userManager;


        public ReviewController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int movieId, int rating, string comment)
        {
            var userId = _userManager.GetUserId(User);

            var review = new Review
            {
                MovieId = movieId,
                UserId = userId, 
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
