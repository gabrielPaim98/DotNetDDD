using DotNetDDD.Domain.Aggregates.UserAggregate.ValueObjects;
using DotNetDDD.Domain.Common.Models;

namespace DotNetDDD.Domain.Aggregates.UserAggregate;
public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public byte[]? PasswordHash { get; private set; }
    public byte[]? PasswordSalt { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }


    private User()
        : base(UserId.CreateUnique())
    { }

    private User(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        byte[]? passwordHash = null,
        byte[]? passwordSalt = null) : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        byte[]? passwordHash = null,
        byte[]? passwordSalt = null
    )
    {
        return new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            DateTime.UtcNow,
            DateTime.UtcNow,
            passwordHash,
            passwordSalt
        );
    }
}
