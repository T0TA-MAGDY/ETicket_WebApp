using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ticketer.Data;
using ticketer.Models;

namespace ticketer.Controllers
{
    [Authorize]
    public class FavoriteController : Controller
    {
        private readonly AppDbContext _context;

        public FavoriteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Toggle([FromBody] FavoriteRequest request)
        {
            if (request == null || request.MovieId == 0)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var existingFavorite = await _context.Favorites
                .FirstOrDefaultAsync(f => f.MovieId == request.MovieId && f.UserId == userId);

            if (existingFavorite == null)
            {
                var favorite = new Favorite
                {
                    MovieId = request.MovieId,
                    UserId = userId
                };

                _context.Favorites.Add(favorite);
                await _context.SaveChangesAsync();
                return Json(new { favorited = true });
            }
            else
            {
                _context.Favorites.Remove(existingFavorite);
                await _context.SaveChangesAsync();
                return Json(new { favorited = false });
            }
        }

        // Optional: View user's favorite movies
        public async Task<IActionResult> MyFavorites()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var favorites = await _context.Favorites
                .Where(f => f.UserId == userId)
                .Include(f => f.Movie)
                .Select(f => f.Movie)
                .ToListAsync();

            return View(favorites); // You'll need a corresponding View
        }
    }

    public class FavoriteRequest
    {
        public int MovieId { get; set; }
    }
}