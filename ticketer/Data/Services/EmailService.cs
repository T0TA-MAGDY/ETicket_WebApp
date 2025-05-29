using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ticketer.Models;
using ticketer.ViewModels; 
using RazorLight;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;
    private readonly IConfiguration _config;
    private readonly RazorLightEngine _razorEngine;

    public EmailService(ILogger<EmailService> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
        _razorEngine = new RazorLightEngineBuilder()
            .UseFileSystemProject(Path.Combine(Directory.GetCurrentDirectory(), "EmailTemplates"))
            .UseMemoryCachingProvider()
            .Build();
    }

    public async Task SendEmailAsync(string toEmail, string subject, string htmlMessage)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_config["Email:From"]));
        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = subject;
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

        using var smtp = new SmtpClient();

        try
        {
            await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_config["Email:Username"], _config["Email:Password"]);
            await smtp.SendAsync(email);
            _logger.LogInformation("Email sent to {Email}", toEmail);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send email to {Email}", toEmail);
        }
        finally
        {
            await smtp.DisconnectAsync(true);
        }
    }

    public async Task SendNewFilmAnnouncementAsync(List<ApplicationUser> users, Movie movie)
    {
        foreach (var user in users)
        {
            var model = new NewFilmEmailVM
            {
                Name = user.FullName,
                MovieTitle = movie.Name,
                Description = movie.Description,
            };

            string body;
            try
            {
                body = await _razorEngine.CompileRenderAsync("NewFilmNotification.cshtml", model);
                _logger.LogInformation("Successfully rendered email for {Email}", user.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to render NewFilmNotification.cshtml for {Email}", user.Email);
                body = $"Hi {model.Name}, a new movie \"{model.MovieTitle}\" is now available!";
            }

            try
            {
                await SendEmailAsync(user.Email, $"New Movie: {movie.Name}", body);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send new movie email to {Email}", user.Email);
            }
        }
    }
}
