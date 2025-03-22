using Framework.Core.Domain.Exceptions;
using Framework.Core.Domain.ValueObjects;
using Utilities.Extensions;

namespace Framework.Core.Domain.Toolkits.ValueObjects;

public class Email : BaseValueObject<Email>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static Email FromString(string value) => new(value);
    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            RequiredException.Throw(nameof(Email));
        }

        if (!value.IsValidEmail())
        {
            NotValidException.Throw(nameof(Email));
        }


        Value = value;
    }
    private Email() { }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion

    #region Operator Overloading

    public static explicit operator string(Email title) => title.Value;
    public static implicit operator Email(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion
}