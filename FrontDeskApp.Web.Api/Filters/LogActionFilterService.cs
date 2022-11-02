using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FrontDeskApp.Web.Api.Filters;

public class LogActionFilterService : IResultFilter
{
	private readonly ILogger _logger;

	public LogActionFilterService(
		ILogger<LogActionFilterService> logger)
	{
		_logger = Guard.Against.Null(logger, nameof(logger));
	}

	public void OnResultExecuting(
		ResultExecutingContext context)
	{
		_logger.LogInformation($"Start: {context.ActionDescriptor.DisplayName}");
	}

	public void OnResultExecuted(
		ResultExecutedContext context)
	{
		_logger.LogInformation($"End: {context.ActionDescriptor.DisplayName}");
	}
}
