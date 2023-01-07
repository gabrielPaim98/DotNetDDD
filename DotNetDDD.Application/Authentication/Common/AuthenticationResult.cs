
using DotNetDDD.Domain.Aggregates.UserAggregate;

namespace DotNetDDD.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);