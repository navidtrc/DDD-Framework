using Ardalis.GuardClauses;
using Framework.Core.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Framework.Core.Domain.Toolkits.ValueObjects;

public class PhoneNumber : BaseValueObject<PhoneNumber>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public PhoneNumber(string value)
    {
        Guard.Against.NullOrWhiteSpace(value, nameof(PhoneNumber));
        string phoneNumberPatterin = @"^09\d{9}$";
        // Add regex validation for phone numbers
        if (!Regex.IsMatch(value, phoneNumberPatterin))
        {
            throw new ArgumentException("Phone number must match the pattern 09123456789.", nameof(value));
        }

        Value = value;
    }
    private PhoneNumber() { }
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
