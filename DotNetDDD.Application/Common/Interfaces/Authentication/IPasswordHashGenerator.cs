namespace DotNetDDD.Application.Common.Interfaces.Authentication;

public interface IPasswordHashGenerator
{
    void CreatePasswordHash(
        string password,
        out byte[] passwordHash,
        out byte[] passwordSalt);

    bool VerifyPasswordHash(
        string password,
        byte[] passwordHash,
        byte[] passwordSalt);
}