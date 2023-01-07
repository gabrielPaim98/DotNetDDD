using DotNetDDD.Domain.Common.Models;

namespace DotNetDDD.Domain.Aggregates.UserAggregate.ValueObjects;

public sealed class UserId : ValueObject
{
    public Guid Value { get; private set; }

    private UserId() { }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static implicit operator UserId(Guid id)
    {
        return new UserId(id);
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
