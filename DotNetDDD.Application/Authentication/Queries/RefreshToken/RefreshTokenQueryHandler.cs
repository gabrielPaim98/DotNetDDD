using DotNetDDD.Application.Authentication.Common;
using DotNetDDD.Application.Common.Interfaces.Authentication;
using DotNetDDD.Application.Common.Interfaces.Persistence;
using DotNetDDD.Domain.Common.Errors;
using DotNetDDD.Domain.Aggregates.UserAggregate;
using ErrorOr;
using MediatR;

namespace DotNetDDD.Application.Authentication.Queries.RefreshToken;

public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;

    public RefreshTokenQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RefreshTokenQuery query,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (String.IsNullOrEmpty(query.UserId)
             || _userRepository.GetUserById(query.UserId) is not User user)
        {
            return Errors.Authentication.NotAuthenticated;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
           user,
           token
       );
    }
}
