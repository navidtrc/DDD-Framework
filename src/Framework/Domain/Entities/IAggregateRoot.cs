using Framework.Domain.Events;

namespace Framework.Domain.Entities;

public interface IAggregateRoot
{
    void ClearEvents();
    IEnumerable<IDomainEvent> GetEvents();
}