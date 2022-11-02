using System.Net.Mail;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Infrastructure.Configurations;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FrontDeskApp.Infrastructure.Services;

public sealed class EmailService : IEmailService
{
	private readonly EmailConfig _emailConfig;

	public EmailService(
		EmailConfig emailConfig)
	{
		_emailConfig = Guard.Against.Null(emailConfig, nameof(emailConfig));
	}

	public async Task SendAsync(
		MailMessage message,
		CancellationToken cancellationToken = default)
	{
		var client = new SendGridClient(_emailConfig.EmailKey);


		var msg = new SendGridMessage()
		{
			From = new EmailAddress(message.From.Address, message.From.DisplayName),
			Subject = message.Subject,
			PlainTextContent = message.IsBodyHtml ? String.Empty : message.Body,
			HtmlContent = message.IsBodyHtml ? message.Body : string.Empty,
		};

		foreach (var to in message.To)
		{
			msg.AddTo(to.Address);
		}

		var response = await client.SendEmailAsync(msg, cancellationToken);
	}
}
