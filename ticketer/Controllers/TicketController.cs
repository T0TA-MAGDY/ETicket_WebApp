using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticketer.Data;
using ticketer.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;
using SendGrid.Helpers.Errors.Model;
using static QRCoder.PayloadGenerator;
using QRCoder;
using System.Drawing;

namespace ticketer.Controllers
{
    public class TicketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TicketController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // View seats for a specific Timing
        public async Task<IActionResult> ChooseSeats(int id)
        {
            var tickets = await _context.Tickets
                .Where(t => t.Timing_Id == id)
                .ToListAsync();

            // Get the Timing details (including price)
            var timing = await _context.Timings
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (timing == null || tickets == null || tickets.Count == 0)
                return NotFound("No seats found for this timing.");

            ViewBag.Timing_Id = id;
            ViewBag.Price = timing.Price;  // Pass the price to the view
            return View(tickets);
        }

        // Book selected seats

        [HttpPost]
        public async Task<IActionResult> BookSeats(int timingId, List<int> selectedTicketIds)
        {
            if (selectedTicketIds == null || selectedTicketIds.Count == 0)
                return BadRequest("No seats selected.");

            var timing = await _context.Timings
                .Where(t => t.Id == timingId)
                .FirstOrDefaultAsync();

            if (timing == null)
                return NotFound("Invalid timing.");

            var tickets = await _context.Tickets
                .Where(t => selectedTicketIds.Contains(t.Ticket_Id) && t.Timing_Id == timingId && !t.IsBooked)
                .ToListAsync();

            if (tickets.Count != selectedTicketIds.Count)
                return BadRequest("Some seats were already booked. Please refresh and try again.");

            var userId = _userManager.GetUserId(User);
            if (userId == null)
                return View("NotAuthorized");

            // Calculate the total price
            // Calculate total price depending on seat type
            decimal totalPrice = 0;
            foreach (var ticket in tickets)
            {
                decimal seatPrice = timing.Price;

                if (ticket.SeatType == "Premium")
                {
                    seatPrice += 50;
                }


                totalPrice += seatPrice;
            }

            // Create a new ticket order
            var order = new TicketOrder
            {
                User_Id = userId,
                Amount = tickets.Count,
                TotalPrice = totalPrice,
                PaymentStatus = "Pending",
                BookingTime = DateTime.UtcNow
            };

            _context.TicketOrders.Add(order);
            await _context.SaveChangesAsync();

            // Update the selected tickets
            foreach (var ticket in tickets)
            {
                ticket.Order_Id = order.Order_Id;
                _context.Tickets.Update(ticket);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("BookingConfirmation", new { orderId = order.Order_Id });
        }

        // Booking confirmation page
        public async Task<IActionResult> BookingConfirmation(int orderId)
        {
            var order = await _context.TicketOrders
                .Include(o => o.Tickets)
                .ThenInclude(t => t.timing)
                .ThenInclude(t => t.Showtime)
                .ThenInclude(s => s.Cinema)
                .Include(o => o.Tickets)
                .ThenInclude(t => t.timing)
                    .ThenInclude(t => t.Showtime)
                        .ThenInclude(s => s.Movie)

                .FirstOrDefaultAsync(o => o.Order_Id == orderId);

            if (order == null)
            {
                return NotFound("Order not found.");
            }

            return View(order);
        }

        public IActionResult GenerateQr(int bookingId)
        {
            var booking = _context.TicketOrders
                .Include(o => o.Tickets)
                    .ThenInclude(t => t.timing)
                    .ThenInclude(t => t.Showtime)
                    .ThenInclude(s => s.Cinema)
                .Include(o => o.Tickets)
                    .ThenInclude(t => t.timing)
                    .ThenInclude(t => t.Showtime)
                    .ThenInclude(s => s.Movie)
                .FirstOrDefault(b => b.Order_Id == bookingId);

            if (booking == null)
                return NotFound();

            string bookingUrl = $"{Request.Scheme}://{Request.Host}/Booking/ConfirmBooking/{bookingId}";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(bookingUrl, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qrCode.GetGraphic(20);
            using var qrStream = new MemoryStream(qrCodeBytes);
            Bitmap qrBitmap = new Bitmap(qrStream);

            var movieName = booking.Tickets.FirstOrDefault()?.timing?.Showtime?.Movie?.Name ?? "N/A";
            var cinemaName = booking.Tickets.FirstOrDefault()?.timing?.Showtime?.Cinema?.Name ?? "N/A";
            var date = booking.Tickets.FirstOrDefault()?.timing?.Showtime?.Date.ToString("yyyy-MM-dd") ?? "N/A";
            var time = booking.Tickets.FirstOrDefault()?.timing?.StartTime.ToString(@"hh\:mm") ?? "N/A";

            var seatDetails = booking.Tickets
                .Select(t => $"Seat {t.SeatNumber}, Row {t.RowNumber}")
                .ToList();

            // --- Define Drawing Parameters ---
            int qrCodeSize = 180; // Fixed size for QR code (pixels)
            int footerHeight = 70; // Dedicated space for the footer area
            int padding = 30; // Padding/margins from ticket edges

            // 4. Calculate Dynamic Ticket Height (to solve overlap/spacing issues)
            // Base height for static content (Title, Movie, Cinema, Date, Time, "Seats:" header)
            // Estimated based on font sizes and line spacing. Adjust if your visual needs change.
            float baseContentHeight = 20 + 26 + (4 * 40) + 40; // Title Y + Title Height + (4 lines * line_height) + "Seats:" header height

            // Height required for the dynamic list of seats
            float seatListHeight = seatDetails.Count * 30; // 30 pixels per seat detail line

            // Minimum height for the ticket (to ensure it doesn't become too small)
            int minHeight = 300;

            // Total height required for all text content (including seats)
            float requiredContentHeight = baseContentHeight + seatListHeight;

            // Total height required to accommodate the QR code with its padding
            float requiredSpaceForQr = qrCodeSize + (padding * 2);

           
            int dynamicHeight = (int)Math.Max(minHeight, Math.Max(requiredContentHeight, requiredSpaceForQr) + footerHeight + (padding * 2));

            

            int width = 750;
            using Bitmap ticket = new Bitmap(width, dynamicHeight);
            using Graphics g = Graphics.FromImage(ticket);
            g.Clear(Color.WhiteSmoke);

            using Pen borderPen = new Pen(Color.Gray, 4);
            g.DrawRectangle(borderPen, 10, 10, width - 20, dynamicHeight - 20);

            using Font titleFont = new Font("Arial", 26, FontStyle.Bold);
            using Font font = new Font("Arial", 18);
            using SolidBrush brush = new SolidBrush(Color.Black);

            // Cinema Logo
            string logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "cinema_logo.png");
            if (System.IO.File.Exists(logoPath))
            {
                using var logoImage = new Bitmap(logoPath);
                g.DrawImage(logoImage, new Rectangle(width - 160, 20, 130, 60));
            }

            g.DrawString("Movie Ticket", titleFont, brush, new PointF(30, 20));

            float yPos = 100;
            g.DrawString($"Movie: {movieName}", font, brush, new PointF(30, yPos));
            yPos += 40;
            g.DrawString($"Cinema: {cinemaName}", font, brush, new PointF(30, yPos));
            yPos += 40;
            g.DrawString($"Date: {date}", font, brush, new PointF(30, yPos));
            yPos += 40;
            g.DrawString($"Time: {time}", font, brush, new PointF(30, yPos));

            yPos += 40;
            g.DrawString("Seats:", font, brush, new PointF(30, yPos));

            foreach (var seat in seatDetails)
            {
                yPos += 30;
                g.DrawString($"- {seat}", font, brush, new PointF(50, yPos));
            }

            // QR Code
            g.DrawImage(qrBitmap, new Rectangle(width - 180, (dynamicHeight / 2) - 80, 150, 150));

            // Footer Line
            g.DrawLine(new Pen(Color.DarkGray, 2), 30, dynamicHeight - 60, width - 30, dynamicHeight - 60);

            using Font footerFont = new Font("Arial", 12, FontStyle.Italic);
            g.DrawString($"Order ID: {bookingId}", footerFont, Brushes.Gray, new PointF(30, dynamicHeight - 50));
            g.DrawString("Thank you for booking with us!", footerFont, Brushes.Gray, new PointF(width - 300, dynamicHeight - 50));

            using var ms = new MemoryStream();
            ticket.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] ticketBytes = ms.ToArray();

            return File(ticketBytes, "image/png", "BookingTicket.png");
        }


        public async Task<IActionResult> ConfirmPaymentAndBookSeats(int orderId)
{
    var order = await _context.TicketOrders
        .Include(o => o.Tickets)
        .FirstOrDefaultAsync(o => o.Order_Id == orderId);

    if (order == null)
    {
                       return NotFound("Order not found.");

    }

    if (order.PaymentStatus != "Paid")
    {
        order.PaymentStatus = "Paid";  // Mark payment as confirmed

        foreach (var ticket in order.Tickets)
        {
            ticket.IsBooked = true;  // Book each ticket
            _context.Tickets.Update(ticket);  // Update ticket status
        }

        _context.TicketOrders.Update(order);  // Update order status
        await _context.SaveChangesAsync();  // Save changes to the database

    }

return RedirectToAction("BookingConfirmation", new { orderId = orderId });
}




    }
}
