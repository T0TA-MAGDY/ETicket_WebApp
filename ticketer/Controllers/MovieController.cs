using System;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ticketer.Data;
using ticketer.Models;
using ticketer.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ticketer.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _context;

        public MovieController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies
                .Include(m => m.Producer)
                .Include(m => m.MovieActors)
                    .ThenInclude(ma => ma.Actor)
                .ToList();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Producer)
                .Include(m => m.MovieActors)
                    .ThenInclude(ma => ma.Actor)
                .Include(m => m.Showtimes)
                    .ThenInclude(s => s.Cinema)
                .Include(m => m.Showtimes)
                    .ThenInclude(s => s.Timings)
                .FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }


        // GET: Movie/Add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var viewModel = new MovieViewModel
            {
                FormOptions = new MovieFormOptionsVM
                {
                    Actors = await GetActors(),
                    Producers = await GetProducers(),
                    Cinemas = await GetCinemas()
                },
                Showtimes = new List<ShowtimeInputVM> { new ShowtimeInputVM() }
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAdd(MovieViewModel model)
        {
            // Initialize collections if null
            Console.WriteLine($"ActorIds type: {model.ActorIds?.GetType()}");
            Console.WriteLine($"First actor type: {model.ActorIds?.FirstOrDefault().GetType()}");

            // Custom validation
            if (model.ProducerId <= 0)
                ModelState.AddModelError("ProducerId", "Please select a producer");

            if (!model.ActorIds.Any())
                ModelState.AddModelError("ActorIds", "Please select at least one actor");

            if (!model.Showtimes.Any(s => s.CinemaId > 0))
                ModelState.AddModelError("", "Please add at least one valid showtime");

            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {


                        Debug.WriteLine(error.ErrorMessage);

                    }
                }
                model.FormOptions = new MovieFormOptionsVM
                {
                    Actors = await GetActors(),
                    Producers = await GetProducers(),
                    Cinemas = await GetCinemas()

                };
                return View("Add", model);
            }


            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Save Movie
                var movie = new Movie
                {
                    Name = model.Name,
                    Description = model.Description,
                    ImageURL = model.ImageURL,
                    TrailerURL = model.TrailerURL,
                    ReleaseDate = model.ReleaseDate,
                    MovieCategory = model.MovieCategory,
                    ProducerId = model.ProducerId
                };
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();

                // Save Actors
                foreach (var actorId in model.ActorIds)
                {
                    _context.MovieActors.Add(new MovieActor
                    {
                        MovieId = movie.Id,
                        ActorId = actorId
                    });
                }

                // Save Showtimes
                foreach (var showtime in model.Showtimes.Where(s => s.CinemaId > 0))
                {
                    var newShowtime = new Showtime
                    {
                        Movie_Id = movie.Id,
                        Cinema_Id = showtime.CinemaId,
                        Date = showtime.Date
                    };
                    _context.Showtimes.Add(newShowtime);
                    await _context.SaveChangesAsync(); // Get ID

                    _context.Timings.Add(new Timing
                    {
                        showtime_id = newShowtime.Showtime_Id,
                        StartTime = showtime.StartTime
                    });
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                ModelState.AddModelError("", "Error saving movie: " + ex.Message);
                model.FormOptions.Producers = await GetProducers();
                model.FormOptions.Actors = await GetActors();
                model.FormOptions.Cinemas = await GetCinemas();
                return View("Add", model);
            }
        }

        private async Task<List<SelectListItem>> GetActors()
        {
            return await _context.Actors
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.FullName
                }).ToListAsync();
        }

        private async Task<List<SelectListItem>> GetProducers()
        {
            return await _context.Producers
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.FullName
                }).ToListAsync();
        }

        private async Task<List<SelectListItem>> GetCinemas()
        {
            return await _context.Cinemas
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToListAsync();
        }


    }
}