using DotNetDDD.Domain.Aggregates.UserAggregate;

namespace DotNetDDD.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
