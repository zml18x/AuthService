using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using AuthService.Application.Interfaces;

namespace AuthService.Infrastructure.Services;

public class EmailService(IConfiguration configuration) : IEmailService
{
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException(
                "Failed to send email. Email address cannot be null, empty, or whitespace. ", nameof(email));

        var client = new SendGridClient(configuration["SENDGRID_API_KEY"]);

        var msg = new SendGridMessage
        {
            From = new EmailAddress(configuration["SENDGRID_SENDER_EMAIL"]),
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = $"<strong>{message}</strong>"
        };

        msg.AddTo(new EmailAddress($"{email}"));

        await client.SendEmailAsync(msg).ConfigureAwait(false);
    }
}