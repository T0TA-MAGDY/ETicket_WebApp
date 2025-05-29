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
        public IActionResult Index(string searchString)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Producer)
                .Include(m => m.MovieActors)
                    .ThenInclude(ma => ma.Actor)
                .Include(m => m.Showtimes)
                    .ThenInclude(s => s.Cinema)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                moviesQuery = moviesQuery.Where(m =>
                    m.Name.Contains(searchString) ||
                    m.MovieCategory.ToString().Contains(searchString) ||
                    m.Showtimes.Any(s => s.Cinema.Name.Contains(searchString)));
            }

            var movies = moviesQuery.ToList();
            return View(movies);
        }


       public IActionResult Showdetails(int id)
        {
            var movie = _context.Movies
            .Include(m => m.Reviews)
       .Include(m => m.Showtimes)
           .ThenInclude(st => st.Cinema)
       .Include(m => m.Showtimes.Where(s => s.Date >= DateTime.Today))
           .ThenInclude(st => st.Timings)
           .Include(p => p.Producer)
           .Include(m => m.MovieActors)
           .ThenInclude(ma => ma.Actor)
       .FirstOrDefault(m => m.Id == id);


            if (movie == null)
            {
                return NotFound();
            }
            var relatedmovie = _context.Movies.Where(m => m.Id != id && m.MovieCategory == movie.MovieCategory).ToList();
            ViewBag.RelatedMovies = relatedmovie;
            ViewBag.Reviews = _context.Reviews
    .Where(r => r.MovieId == id)
    .Include(r => r.User)
    .OrderByDescending(r => r.CreatedAt)
    .ToList();
ViewBag.AverageRating = movie.Reviews?.Any() == true 
    ? Math.Round(movie.Reviews.Average(r => r.Rating), 1) 
    : (double?)null;
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

                    var newTiming = new Timing
                    {
                        showtime_id = newShowtime.Showtime_Id,
                        StartTime = showtime.StartTime,
                        Price = showtime.Price
                    };
                    _context.Timings.Add(newTiming);
                    await _context.SaveChangesAsync();


                    var tickets = new List<Ticket>();

                    for (int row = 1; row <= 10; row++) // 10 rows
                    {
                        for (int seat = 1; seat <= 8; seat++) // 15 seats per row
                        {
                            var ticket = new Ticket
                            {
                                Timing_Id = newTiming.Id,
                                RowNumber = row,
                                SeatNumber = seat,
                                SeatType = (row <= 2) ? "Premium" : "Regular", // First 2 rows Premium
                                IsBooked = false
                            };
                            _context.Tickets.Add(ticket);
                        }
                    }

                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                var errorMessage = ex.InnerException?.Message ?? ex.Message;
                ModelState.AddModelError("", "Error saving movie: " + errorMessage);

                model.FormOptions.Producers = await GetProducers();
                model.FormOptions.Actors = await GetActors();
                model.FormOptions.Cinemas = await GetCinemas();
                return View("Add", model);
            }
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Producer)
                .Include(m => m.MovieActors)
                    .ThenInclude(ma => ma.Actor)
                .Include(m => m.Showtimes)
                    .ThenInclude(s => s.Cinema)
                .Include(m => m.Showtimes)
                    .ThenInclude(s => s.Timings)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            var viewModel = new MovieViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                ImageURL = movie.ImageURL,
                TrailerURL = movie.TrailerURL,
                ReleaseDate = movie.ReleaseDate,
                MovieCategory = movie.MovieCategory,
                ProducerId = movie.ProducerId,
                ActorIds = movie.MovieActors.Select(ma => ma.ActorId).ToList(),
                Showtimes = movie.Showtimes.SelectMany(s => s.Timings.Select(t => new ShowtimeInputVM
                {
                    ShowTimeId = s.Showtime_Id,
                    TimingId = t.Id,
                    CinemaId = s.Cinema_Id,
                    Date = s.Date,
                    StartTime = t.StartTime,
                    Price = t.Price
                })).ToList(),
                FormOptions = new MovieFormOptionsVM
                {
                    Actors = await GetActors(),
                    Producers = await GetProducers(),
                    Cinemas = await GetCinemas()
                }
            };

            return View("Edit", viewModel);
        }

        // POST: Movie/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.FormOptions = new MovieFormOptionsVM
                {
                    Actors = await GetActors(),
                    Producers = await GetProducers(),
                    Cinemas = await GetCinemas()
                };
                return View(model);
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();

            movie.Name = model.Name;
            movie.Description = model.Description;
            movie.ImageURL = model.ImageURL;
            movie.TrailerURL = model.TrailerURL;
            movie.ReleaseDate = model.ReleaseDate;
            movie.MovieCategory = model.MovieCategory;
            movie.ProducerId = model.ProducerId;

            // Remove old actors
            var existingActors = _context.MovieActors.Where(ma => ma.MovieId == id).ToList();
            _context.MovieActors.RemoveRange(existingActors);
            foreach (var actorId in model.ActorIds)
            {
                _context.MovieActors.Add(new MovieActor { MovieId = id, ActorId = actorId });
            }

            // Gather form IDs
            var submittedShowtimeIds = model.Showtimes.Where(s => s.ShowTimeId > 0).Select(s => s.ShowTimeId).ToList();
            var submittedTimingIds = model.Showtimes.Where(s => s.TimingId > 0).Select(s => s.TimingId).ToList();

            // Load existing showtimes
            var existingShowtimes = await _context.Showtimes
                .Include(s => s.Timings)
                .Where(s => s.Movie_Id == id)
                .ToListAsync();

            // Remove deleted showtimes
            var showtimesToRemove = existingShowtimes
                .Where(es => !submittedShowtimeIds.Contains(es.Showtime_Id))
                .ToList();

            foreach (var st in showtimesToRemove)
            {
                var timingIds = st.Timings.Select(t => t.Id).ToList();
                var tickets = _context.Tickets.Where(t => timingIds.Contains(t.Timing_Id));
                _context.Tickets.RemoveRange(tickets);

                _context.Timings.RemoveRange(st.Timings);
                _context.Showtimes.Remove(st);
            }

            // Handle updates and new showtimes/timings
            foreach (var showtimeVM in model.Showtimes.Where(s => s.CinemaId > 0))
            {
                Showtime existingShowtime = null;

                if (showtimeVM.ShowTimeId > 0)
                {
                    existingShowtime = existingShowtimes.FirstOrDefault(s => s.Showtime_Id == showtimeVM.ShowTimeId);
                    if (existingShowtime != null)
                    {
                        existingShowtime.Cinema_Id = showtimeVM.CinemaId;
                        existingShowtime.Date = showtimeVM.Date;

                        if (showtimeVM.TimingId > 0)
                        {
                            var existingTiming = existingShowtime.Timings.FirstOrDefault(t => t.Id == showtimeVM.TimingId);
                            if (existingTiming != null)
                            {
                                existingTiming.StartTime = showtimeVM.StartTime;
                                existingTiming.Price = showtimeVM.Price;
                            }
                        }
                        else
                        {
                            var newTiming = new Timing
                            {
                                showtime_id = existingShowtime.Showtime_Id,
                                StartTime = showtimeVM.StartTime,
                                Price = showtimeVM.Price
                            };
                            _context.Timings.Add(newTiming);
                            await _context.SaveChangesAsync();

                            for (int row = 1; row <= 10; row++)
                            {
                                for (int seat = 1; seat <= 8; seat++)
                                {
                                    _context.Tickets.Add(new Ticket
                                    {
                                        Timing_Id = newTiming.Id,
                                        RowNumber = row,
                                        SeatNumber = seat,
                                        SeatType = (row <= 2) ? "Premium" : "Regular",
                                        IsBooked = false
                                    });
                                }
                            }
                        }
                    }
                }
                else
                {
                    var newShowtime = new Showtime
                    {
                        Movie_Id = id,
                        Cinema_Id = showtimeVM.CinemaId,
                        Date = showtimeVM.Date
                    };
                    _context.Showtimes.Add(newShowtime);
                    await _context.SaveChangesAsync();

                    var newTiming = new Timing
                    {
                        showtime_id = newShowtime.Showtime_Id,
                        StartTime = showtimeVM.StartTime,
                        Price = showtimeVM.Price
                    };
                    _context.Timings.Add(newTiming);
                    await _context.SaveChangesAsync();

                    for (int row = 1; row <= 10; row++)
                    {
                        for (int seat = 1; seat <= 8; seat++)
                        {
                            _context.Tickets.Add(new Ticket
                            {
                                Timing_Id = newTiming.Id,
                                RowNumber = row,
                                SeatNumber = seat,
                                SeatType = (row <= 2) ? "Premium" : "Regular",
                                IsBooked = false
                            });
                        }
                    }
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("ShowDetails", new { id = id });
        }
        // GET: Movie/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _context.Movies
                .Include(m => m.Producer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null) return NotFound();

            return View(movie); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.MovieActors)
                .Include(m => m.Showtimes)
                    .ThenInclude(s => s.Timings)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
                return NotFound();

            // Delete related tickets
            foreach (var showtime in movie.Showtimes)
            {
                var timingIds = showtime.Timings.Select(t => t.Id).ToList();
                var tickets = _context.Tickets.Where(t => timingIds.Contains(t.Timing_Id));
                _context.Tickets.RemoveRange(tickets);
            }

            // Delete timings and showtimes
            foreach (var showtime in movie.Showtimes)
            {
                _context.Timings.RemoveRange(showtime.Timings);
            }

            _context.Showtimes.RemoveRange(movie.Showtimes);

            // Delete movie-actor relationships
            _context.MovieActors.RemoveRange(movie.MovieActors);

            // Delete the movie
            _context.Movies.Remove(movie);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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