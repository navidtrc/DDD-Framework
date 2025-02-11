using Ardalis.GuardClauses;
using Framework.Domain.ValueObjects;

namespace Framework.Domain.Toolkits.ValueObjects;

public class Url : BaseValueObject<Url>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public Url(string value)
    {
        Guard.Against.NullOrWhiteSpace(value, nameof(Url));
        if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
        {
            throw new ArgumentException("Invalid URL format.", nameof(value));
        }

        Value = value;
    }
    private Url() { }
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
