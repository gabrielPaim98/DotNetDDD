using ErrorOr;

namespace DotNetDDD.Domain.Common.Errors;
public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCredentials",
            description: "Invalid credentials"
        );

        public static Error NotAuthenticated => Error.Validation(
            code: "Auth.NotAuthenticated",
            description: "User not authenticated"
        );
    }
}