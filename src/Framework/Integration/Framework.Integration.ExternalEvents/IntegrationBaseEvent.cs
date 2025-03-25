using Framework.Core.Domain.ValueObjects;

namespace Framework.Integration.ExternalEvents;

/// <summary>
/// Base event for integration events
/// </summary>
public abstract class IntegrationBaseEvent
{
    /// <summary>
    /// Constructor to generate a new id and set the creation date
    /// </summary>
    public IntegrationBaseEvent()
    {
        BusinessId = Guid.NewGuid();
        CreatedOn = DateTime.Now;
    }

    /// <summary>
    /// Constructor if you got an external method settings the properties.
    /// </summary>
    /// <param name="id">Event ID</param>
    /// <param name="creationDate">Event Creation Date</param>
    public IntegrationBaseEvent(Guid id, DateTime creationOn)
    {
        BusinessId = id;
        CreatedOn = creationOn;
    }

    /// <summary>
    /// Event ID
    /// </summary>
    public BusinessId BusinessId { get; private set; }

    /// <summary>
    /// Event Creation Date
    /// </summary>
    public DateTime CreatedOn { get; private set; }
    
    public string RequestedUserId { get; set; }
}