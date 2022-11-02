using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Notifications;
using FrontDeskApp.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FrontDeskApp.Infrastructure.Services;

internal class DomainEventService : IDomainEventService
{
	private readonly ILogger<DomainEventService> _logger;
	private readonly IPublisher _mediator;

	public DomainEventService(
			ILogger<DomainEventService> logger,
			IPublisher mediator)
	{
		_logger = Guard.Against.Null(logger, nameof(logger));
		_mediator = Guard.Against.Null(mediator, nameof(mediator));
	}

	public async Task PublishAsync(
		DomainEvent domainEvent)
	{
		_logger.LogInformation("Publishing domain event. Event - {event}", domainEvent.GetType().Name);
		await _mediator.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent));
	}

	private INotification GetNotificationCorrespondingToDomainEvent(
			DomainEvent domainEvent)
	{
		return (INotification)Activator.CreateInstance(
			typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent);
	}
}
