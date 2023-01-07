using DotNetDDD.Application.Common.Interfaces.Persistence;
using DotNetDDD.Domain.Aggregates.UserAggregate;

namespace DotNetDDD.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly DotNetDDDDbContext _dbContext;

    public UserRepository(DotNetDDDDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Add(user);
        _dbContext.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.SingleOrDefault(u => u.Email == email);
    }

    public User? GetUserById(string id)
    {
        return _dbContext.Users.SingleOrDefault(u => u.Id.Value.ToString() == id);
    }
}
