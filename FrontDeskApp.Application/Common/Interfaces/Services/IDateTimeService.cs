namespace FrontDeskApp.Application.Common.Interfaces.Services;

/// <summary>
/// An interface to setting the default time setting to be used for the application.
/// </summary>
public interface IDateTimeService
{
	DateTime Now { get; }
	DateOnly NowDateOnly { get; }
}
