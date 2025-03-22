using Ardalis.GuardClauses;
using Framework.Core.Domain.ValueObjects;
using Utilities.DateTimes;

namespace Framework.Core.Domain.Toolkits.ValueObjects;

public class DateOfBirth : BaseValueObject<DateOfBirth>
{
    #region Properties
    public DateTime Value { get; private set; }
    public int Age => (int)((DateTime.Now - Value).TotalDays / 365.25);
    public bool IsLegalAge => Age >= 18;
    public string PersianBirthday => Value.ToShortPersianDateString();
    #endregion

    #region Constructors and Factories
    public DateOfBirth(DateTime value, bool legalAge = false)
    {
        Guard.Against.OutOfRange(value, nameof(DateOfBirth), DateTime.MinValue, DateTime.Now, null, () =>
        {
            throw new ArgumentException("Date of birth must be in the past.", nameof(value));
        });

        if (legalAge && (DateTime.Now - value).TotalDays / 365.25 < 18)
        {
            throw new ArgumentException("Date of birth indicates the person is under 18.", nameof(value));
        }

        Value = value;
    }
    private DateOfBirth() { }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Methods
    public override string ToString() => Value.ToString("yyyy-MM-dd");

    public DateTime GetCurrentYearBirthday()
    {
        var thisYear = DateTime.Now.Year;
        var birthdayThisYear = new DateTime(thisYear, Value.Month, Value.Day);

        // Adjust for leap years if necessary
        if (birthdayThisYear < DateTime.Now)
        {
            return birthdayThisYear.AddYears(1);
        }

        return birthdayThisYear;
    }
    #endregion
}