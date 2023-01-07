using DotNetDDD.Application.Authentication.Common;
using DotNetDDD.Application.Common.Interfaces.Authentication;
using DotNetDDD.Application.Common.Interfaces.Persistence;
using DotNetDDD.Domain.Common.Errors;
using DotNetDDD.Domain.Aggregates.UserAggregate;
using ErrorOr;
using MediatR;

namespace DotNetDDD.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IPasswordHashGenerator _passwordHashGenerator;

    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository,
        IPasswordHashGenerator passwordHashGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _passwordHashGenerator = passwordHashGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        LoginQuery query,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_userRepository.GetUserByEmail(query.Email) is not User user
            || user.PasswordHash == null
            || user.PasswordSalt == null)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (!_passwordHashGenerator.VerifyPasswordHash(
            query.Password,
            user.PasswordHash,
            user.PasswordSalt))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
           user,
           token
       );
    }
}
