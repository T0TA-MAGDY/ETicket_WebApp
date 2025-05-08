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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // MovieActor: many-to-many
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

            // Movie -> Producer
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Producer)
                .WithMany(p => p.Movies)
                .HasForeignKey(m => m.ProducerId)
                .OnDelete(DeleteBehavior.Cascade);  // Explicitly setting no cascading delete
            modelBuilder.Entity<Movie>()
                .Property(m => m.MovieCategory)
                .HasConversion<string>();
            // Showtime -> Movie, Cinema
            modelBuilder.Entity<Showtime>()
      .HasOne(s => s.Cinema)
      .WithMany(c => c.Showtimes)
      .HasForeignKey(s => s.Cinema_Id);

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
            modelBuilder.Entity<Timing>()
                           .HasOne(t => t.Showtime)
                           .WithMany(s => s.Timings)
                           .HasForeignKey(t => t.showtime_id);
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Order)
                .WithMany(o => o.Tickets)
                .HasForeignKey(t => t.Order_Id)
                .OnDelete(DeleteBehavior.NoAction);  // Explicitly setting no cascading delete

            modelBuilder.Entity<Ticket>()
                            .HasOne(t => t.timing)
                            .WithMany(tm => tm.Tickets)
                            .HasForeignKey(t => t.Timing_Id);
            // TicketOrder -> User
            modelBuilder.Entity<TicketOrder>()
                .HasOne(o => o.User)
                .WithMany(u => u.TicketOrders)
                .HasForeignKey(o => o.User_Id)
                .OnDelete(DeleteBehavior.NoAction);  // Explicitly setting no cascading delete
        }

    }
}