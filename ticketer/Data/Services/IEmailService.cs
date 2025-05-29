using ticketer.Models;

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string body);
    Task SendNewFilmAnnouncementAsync(List<ApplicationUser> users, Movie movie);

}