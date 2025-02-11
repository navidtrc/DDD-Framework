using Framework.Domain.ValueObjects;

namespace Framework.Domain.Entities;

public abstract class BaseEntity<TId> : IAuditableEntity
          where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    public TId Id { get; protected set; }
    public BusinessId BusinessId { get; protected set; } = BusinessId.FromGuid(Guid.NewGuid());
    public DateTime CreatedOn { get; protected set; } = DateTime.Now;
    public DateTime? LastUpdatedOn { get; protected set; }
    public bool IsArchived { get; protected set; } = false;

    protected BaseEntity() { }

    public bool Equals(BaseEntity<TId>? other) => this == other;
    public override bool Equals(object? obj) =>
         obj is BaseEntity<TId> otherObject && Id.Equals(otherObject.Id);

    public override int GetHashCode() => Id.GetHashCode();
    public static bool operator ==(BaseEntity<TId> left, BaseEntity<TId> right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(BaseEntity<TId> left, BaseEntity<TId> right)
        => !(right == left);
}

public abstract class Entity : BaseEntity<long>;