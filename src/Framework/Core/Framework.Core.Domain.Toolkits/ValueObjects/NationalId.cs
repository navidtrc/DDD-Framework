using Framework.Core.Domain.Exceptions;
using Framework.Core.Domain.ValueObjects;
using Utilities.Extensions;

namespace Framework.Core.Domain.Toolkits.ValueObjects;

public class NationalId : BaseValueObject<NationalId>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static NationalId FromString(string value) => new(value);
    public NationalId(string value)
    {
        if (!value.IsNationalIdValid())
        {
            NotValidException.Throw(nameof(NationalId));
        }

        Value = value;
    }
    private NationalId() { }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion

    #region Operator Overloading

    public static explicit operator string(NationalId title) => title.Value;
    public static implicit operator NationalId(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;

    #endregion

}

