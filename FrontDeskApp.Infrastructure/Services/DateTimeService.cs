using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Common.Interfaces.Services;

namespace FrontDeskApp.Infrastructure.Services;

[ExcludeFromCodeCoverage]
public class DateTimeService : IDateTimeService
{
	public DateTime Now => DateTime.Now;
	public DateOnly NowDateOnly => DateOnly.FromDateTime(DateTime.Now);
}
