using Framework.Core.Domain.Exceptions;
using Framework.Core.Domain.ValueObjects;
using Utilities.Extensions;

namespace Framework.Core.Domain.Toolkits.ValueObjects;

public class LegalNationalCode : BaseValueObject<LegalNationalCode>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static LegalNationalCode FromString(string value) => new(value);
    private LegalNationalCode(string value)
    {
        if (!value.IsLegalNationalCodeValid())
        {
            NotValidException.Throw(nameof(LegalNationalCode));
        }

        Value = value;
    }
    private LegalNationalCode() { }

    #endregion

    #region Equality Check

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion

    #region Operator Overloading
    public static explicit operator string(LegalNationalCode title) => title.Value;
    public static implicit operator LegalNationalCode(string value) => new(value);
    #endregion
    #region Methods
    public override string ToString() => Value;

    #endregion
}

