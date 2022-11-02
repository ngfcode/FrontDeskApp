using System.Diagnostics.CodeAnalysis;

namespace FrontDeskApp.Infrastructure.Configurations;

[ExcludeFromCodeCoverage]
public sealed class EmailConfig
{
	public string FromEmail { get; set; }
	public string FromName { get; set; }
	public string SmtpServer { get; set; }
	public int Port { get; set; }
	public string UserName { get; set; }
	public string Password { get; set; }
	public string EmailKey { get; set; }
}
