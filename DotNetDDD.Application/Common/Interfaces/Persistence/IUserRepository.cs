using DotNetDDD.Domain.Aggregates.UserAggregate;

namespace DotNetDDD.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    User? GetUserById(string id);
    void Add(User user);
}
