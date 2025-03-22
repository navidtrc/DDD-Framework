using Ardalis.GuardClauses;
using Framework.Core.Domain.ValueObjects;

namespace Framework.Core.Domain.Toolkits.ValueObjects;

public class LandlinePhoneNumber : BaseValueObject<LandlinePhoneNumber>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public LandlinePhoneNumber(string value)
    {
        Guard.Against.LengthOutOfRange(value, 6, 12);

        Value = value;
    }
    private LandlinePhoneNumber() { }
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
