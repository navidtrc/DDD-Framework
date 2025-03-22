using Ardalis.GuardClauses;
using Framework.Core.Domain.ValueObjects;

namespace Framework.Core.Domain.Toolkits.ValueObjects;

public class Quantity : BaseValueObject<Quantity>
{
    #region Properties
    public int Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public Quantity(int value)
    {
        Guard.Against.OutOfRange(value, nameof(Quantity), 0, int.MaxValue, null, () =>
        {
            throw new ArgumentException("Quantity must be non-negative.", nameof(value));
        });

        Value = value;
    }
    private Quantity() { }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Methods
    public override string ToString() => Value.ToString();
    #endregion
}