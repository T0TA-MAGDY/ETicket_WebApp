using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using RazorLight;
using ticketer.ViewModels;
using System.IO;
using System.Threading.Tasks;

public class EmailService : IEmailService
{
    private readonly string _apiKey;
    private readonly ILogger<EmailService> _logger;

    public EmailService(string apiKey , ILogger<EmailService> logger)
    {
        _apiKey = apiKey;
        _logger = logger;

    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var client = new SendGridClient(_apiKey);
        var from = new EmailAddress("toot.ma.2022@gmail.com", "Ticketer");
        var to = new EmailAddress(toEmail);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);
        var response = await client.SendEmailAsync(msg);

        // ✅ Log to server console
        _logger.LogInformation("SendGrid sent to {Email} with status {Status}", toEmail, response.StatusCode);
        string responseBody = await response.Body.ReadAsStringAsync();
        _logger.LogInformation("SendGrid response body: {Body}", responseBody);
    }
 

public async Task<string> RenderPasswordResetEmailAsync(PasswordResetEmailModel model)
{
    var engine = new RazorLightEngineBuilder()
        .UseFileSystemProject(Path.Combine(Directory.GetCurrentDirectory(), "EmailTemplates")).Build();

    string templateName = "ResetPasswordEmailTemplate.cshtml";

    string emailBody = await engine.CompileRenderAsync(templateName, model);
    return emailBody;
}
}
