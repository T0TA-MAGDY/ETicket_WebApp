using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ticketer.Models;
namespace ticketer.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<TicketOrder> TicketOrders { get; set; }
        public DbSet<Timing> Timings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

    // MovieActor: Many-to-Many between Movies and Actors
            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId);

    // Movie -> Producer: Many Movies belong to one Producer
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Producer)
                .WithMany(p => p.Movies)
                .HasForeignKey(m => m.ProducerId)
                .OnDelete(DeleteBehavior.Cascade);  // Explicitly setting no cascading delete
     // Store MovieCategory enum as string

            modelBuilder.Entity<Movie>()
                .Property(m => m.MovieCategory)
                .HasConversion<string>();
    // Showtime -> Cinema: Many Showtimes in one Cinema
            modelBuilder.Entity<Showtime>()
                .HasOne(s => s.Cinema)
                .WithMany(c => c.Showtimes)
                .HasForeignKey(s => s.Cinema_Id);
    // Showtime -> Movie: Many Showtimes for one Movie

            modelBuilder.Entity<Showtime>()
                .HasOne(s => s.Movie)
                .WithMany(m => m.Showtimes)
                .HasForeignKey(s => s.Movie_Id);


            // Seat -> Cinema
            // modelBuilder.Entity<Seat>()
            //     .HasOne(s => s.Cinema)
            //     .WithMany(c => c.Seats)
            //     .HasForeignKey(s => s.Cinema_Id)
            //     .OnDelete(DeleteBehavior.NoAction);  // Explicitly setting no cascading delete

            // ShowtimeSeat -> Showtime, Seat
            //modelBuilder.Entity<ShowtimeSeat>()
            //    .HasOne(ss => ss.timing)
            //    .WithMany(s => s.ShowtimeSeats)
            //    .HasForeignKey(ss => ss.Timing_Id)
            //    .OnDelete(DeleteBehavior.NoAction);  // Explicitly setting no cascading delete

            //modelBuilder.Entity<ShowtimeSeat>()
            //    .HasOne(ss => ss.Seat)
            //    .WithMany(s => s.ShowtimeSeats)
            //    .HasForeignKey(ss => ss.Seat_Id)
            //    .OnDelete(DeleteBehavior.NoAction);  // Explicitly setting no cascading delete

            // Ticket -> ShowtimeSeat, TicketOrder
            // modelBuilder.Entity<Ticket>()
            //     .HasOne(t => t.ShowtimeSeat)
            //     .WithMany(ss => ss.Tickets)
            //     .HasForeignKey(t => t.ShowtimeSeat_Id)
            //     .OnDelete(DeleteBehavior.NoAction);  // Explicitly setting no cascading delete
               
    // Timing -> Showtime: Many Timings for one Showtime
            modelBuilder.Entity<Timing>()
                .HasOne(t => t.Showtime)
                .WithMany(s => s.Timings)
                .HasForeignKey(t => t.showtime_id);
    // Ticket -> TicketOrder: Many Tickets belong to one Order
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Order)
                .WithMany(o => o.Tickets)
                .HasForeignKey(t => t.Order_Id)
                .OnDelete(DeleteBehavior.Cascade); 
    // Ticket -> Timing: Many Tickets belong to one Timing
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.timing)
                .WithMany(tm => tm.Tickets)
                .HasForeignKey(t => t.Timing_Id)
                .OnDelete(DeleteBehavior.Cascade);
    // TicketOrder -> User: Many Orders belong to one User
            modelBuilder.Entity<TicketOrder>()
                .HasOne(o => o.User)
                .WithMany(u => u.TicketOrders)
                .HasForeignKey(o => o.User_Id)
                .OnDelete(DeleteBehavior.Cascade);  
    // Precision for monetary values
            modelBuilder.Entity<TicketOrder>()
                .Property(t => t.TotalPrice)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Timing>()
                .Property(t => t.Price)
                .HasPrecision(18, 2);
    // Review -> Movie: Many Reviews belong to one Movie
            modelBuilder.Entity<Review>()
           .HasOne(r => r.Movie)
           .WithMany(m => m.Reviews)
           .HasForeignKey(r => r.MovieId)
           .OnDelete(DeleteBehavior.Cascade);
    // Review -> User: Many Reviews belong to one User
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}