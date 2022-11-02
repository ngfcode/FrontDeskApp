using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FrontDeskApp.Application.Common.Behaviors;

/// <summary>
/// A pipeline behavior that handles logging prior to executing the command.
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
[ExcludeFromCodeCoverage]
internal sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
{
	private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

	public LoggingBehavior(
		ILogger<LoggingBehavior<TRequest, TResponse>> logger )
	{
		_logger = Guard.Against.Null(logger, nameof(logger));
	}

	public async Task<TResponse> Handle(
		TRequest request,
		CancellationToken cancellationToken,
		RequestHandlerDelegate<TResponse> next )
	{
		try
		{
			// Request
			_logger.LogInformation($"Handling Request: {typeof(TRequest).Name}");
			_logger.LogInformation($"Parameter(s): {JsonConvert.SerializeObject(request)}");

			var response = await next();

			// Response
			_logger.LogInformation($"Handled Response: {JsonConvert.SerializeObject(response)}");

			return response;
		}

		catch (DbUpdateConcurrencyException ex)
		{
			_logger.LogError(ex, "Exception error");

			TResponse response = (TResponse)Activator.CreateInstance(typeof(TResponse));
			(response as ErrorResult)
				.AddErrorMessage("The record may have been updated or deleted, kindly refresh and try again.");

			return response;
		}

		catch (Exception ex)
		{
			_logger.LogError(ex, "Exception error");

			TResponse response = (TResponse)Activator.CreateInstance(typeof(TResponse));
			(response as ErrorResult)
				.AddErrorMessage("An exception has occurred, and has been reported already.");

			return response;
		}
	}
}
