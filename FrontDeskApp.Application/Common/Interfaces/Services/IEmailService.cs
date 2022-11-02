using System.Net.Mail;

namespace FrontDeskApp.Application.Common.Interfaces.Services;

/// <summary>
/// An interface for defining the method for sending emails.
/// </summary>
public interface IEmailService
{
	Task SendAsync(
		MailMessage messsage,
		CancellationToken cancellationToken = default);
}
