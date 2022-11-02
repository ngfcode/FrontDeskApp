using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Domain.Common;
using MediatR;

namespace FrontDeskApp.Application.Common.Notifications;

/// <summary>
/// This defines the domain event notification to be sent to the notification handler.
/// </summary>
/// <typeparam name="TDomainEvent"></typeparam>
[ExcludeFromCodeCoverage]
public class DomainEventNotification<TDomainEvent> : INotification
		where TDomainEvent : DomainEvent
{
	public TDomainEvent DomainEvent { get; }

	public DomainEventNotification(
		TDomainEvent domainEvent)
	{
		DomainEvent = domainEvent;
	}
}
