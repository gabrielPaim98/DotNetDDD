using DotNetDDD.Application.Authentication.Common;
using DotNetDDD.Application.Common.Interfaces.Authentication;
using DotNetDDD.Application.Common.Interfaces.Persistence;
using DotNetDDD.Domain.Common.Errors;
using DotNetDDD.Domain.Aggregates.UserAggregate;
using ErrorOr;
using MediatR;

namespace DotNetDDD.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IPasswordHashGenerator _passwordHashGenerator;

    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository,
        IPasswordHashGenerator passwordHashGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _passwordHashGenerator = passwordHashGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        _passwordHashGenerator.CreatePasswordHash(command.Password, out byte[] passwordHash, out byte[] passwordSalt);

        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            passwordHash,
            passwordSalt
        );

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}