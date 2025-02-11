using Ardalis.GuardClauses;
using Framework.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Framework.Domain.Toolkits.ValueObjects;

public class OtpCode : BaseValueObject<OtpCode>
{
    #region Properties
    public string? Value { get; private set; }
    public DateTime? Expiry { get; private set; }
    #endregion

    #region Constructors and Factories
    public OtpCode(string value, DateTime expiry)
    {
        Guard.Against.NullOrWhiteSpace(value, nameof(OtpCode));

        // Ensure OTP is numeric and has a specific length (e.g., 6 digits)
        if (!Regex.IsMatch(value, "^\\d{6}$"))
        {
            throw new ArgumentException("OTP must be a 6-digit numeric code.", nameof(value));
        }

        if (expiry <= DateTime.Now)
        {
            throw new ArgumentException("Expiry time must be in the future.", nameof(expiry));
        }

        Value = value;
        Expiry = expiry;
    }
    private OtpCode() { }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Expiry;
    }
    #endregion

    #region Methods
    public override string ToString() => Value;

    public bool IsExpired() => DateTime.Now > Expiry;
    #endregion
}
