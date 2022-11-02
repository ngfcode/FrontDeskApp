using FrontDeskApp.Domain.Common;

namespace FrontDeskApp.Application.Common.Interfaces.Services;

/// <summary>
/// An interface for defining the required services for domain events.
/// </summary>
public interface IDomainEventService
{
	Task PublishAsync(DomainEvent domainEvent);
}
