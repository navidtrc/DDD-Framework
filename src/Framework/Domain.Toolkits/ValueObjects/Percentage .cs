using Ardalis.GuardClauses;
using Framework.Domain.Exceptions;
using Framework.Domain.ValueObjects;

namespace Framework.Domain.Toolkits.ValueObjects;

public class Percentage : BaseValueObject<Percentage>
{
    #region Properties
    public decimal Value { get; private set; }

    #endregion

    #region Constructors and Factories
    public static Percentage FromString(decimal value) => new(value);
    public Percentage(decimal value)
    {
        Guard.Against.OutOfRange(value, nameof(Percentage), 0, 100, null, () =>
        {
            ValueBetweenException.Throw(nameof(Percentage), 0, 100);
            return null;
        });

        Value = value;
    }
    private Percentage() { }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion

    #region Operator Overloading

    public static explicit operator decimal(Percentage percent) => percent.Value;
    public static implicit operator Percentage(decimal value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => $"{Value}%";

    public static Percentage FromFraction(decimal fraction)
    {
        if (fraction < 0 || fraction > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(fraction), "Fraction must be between 0 and 1.");
        }

        return new Percentage(fraction * 100);
    }
    public decimal ToFraction()
    {
        return Value / 100;
    }

    public static Percentage operator +(Percentage a, Percentage b)
    {
        return new Percentage(a.Value + b.Value);
    }

    public static Percentage operator -(Percentage a, Percentage b)
    {
        return new Percentage(a.Value - b.Value);
    }
    #endregion
}

