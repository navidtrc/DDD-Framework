using Ardalis.GuardClauses;
using Framework.Core.Domain.ValueObjects;
using System.Net;

namespace Framework.Core.Domain.Toolkits.ValueObjects;

public class IpAddress : BaseValueObject<IpAddress>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public IpAddress(string value)
    {
        Guard.Against.NullOrWhiteSpace(value, nameof(IpAddress));
        if (!IPAddress.TryParse(value, out _))
        {
            throw new ArgumentException("Invalid IP address format.", nameof(value));
        }

        Value = value;
    }
    private IpAddress() { }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion
}
