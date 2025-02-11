using Ardalis.GuardClauses;
using Framework.Domain.Exceptions;
using Framework.Domain.ValueObjects;
namespace Framework.Domain.Toolkits.ValueObjects;

public class Price : BaseValueObject<Price>
{
    #region Properties
    public decimal Amount { get; private set; }

    #endregion

    #region Constructors and Factories
    public Price(decimal value)
    {
        Guard.Against.OutOfRange(value, nameof(Price), GlobalConstants.PRICE.MinValue, GlobalConstants.PRICE.MinValue, null, () =>
        {
            ValueBetweenException.Throw(nameof(Price), (long)GlobalConstants.PRICE.MinValue, (long)GlobalConstants.PRICE.MinValue);
            return null;
        });

        Amount = value;
    }
    private Price() { }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
    }

    #endregion

    #region Operator Overloading

    public static explicit operator decimal(Price percent) => percent.Amount;
    public static implicit operator Price(decimal value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => $"{Amount}%";

    public static Price FromFraction(decimal fraction)
    {
        if (fraction < 0 || fraction > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(fraction), "Fraction must be between 0 and 1.");
        }

        return new Price(fraction * 100);
    }
    public decimal ToFraction()
    {
        return Amount / 100;
    }

    public static Price operator +(Price a, Price b)
    {
        return new Price(a.Amount + b.Amount);
    }

    public static Price operator -(Price a, Price b)
    {
        return new Price(a.Amount - b.Amount);
    }
    #endregion
}

