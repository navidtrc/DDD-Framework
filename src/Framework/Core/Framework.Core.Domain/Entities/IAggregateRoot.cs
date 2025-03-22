using Framework.Core.Domain.Events;

namespace Framework.Core.Domain.Entities;

public interface IAggregateRoot
{
    void ClearEvents();
    IEnumerable<IDomainEvent> GetEvents();
}