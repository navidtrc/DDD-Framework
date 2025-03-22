using Framework.Core.Domain.Events;

namespace Framework.Core.Contracts.ApplicationServices.Events;

public interface IEventDispatcher
{
    Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent;
}