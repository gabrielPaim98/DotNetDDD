using DotNetDDD.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace DotNetDDD.Application.Authentication.Queries.RefreshToken;

public record RefreshTokenQuery(
    string? UserId) : IRequest<ErrorOr<AuthenticationResult>>;