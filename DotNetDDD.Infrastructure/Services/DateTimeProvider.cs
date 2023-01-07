using DotNetDDD.Application.Common.Interfaces.Services;

namespace DotNetDDD.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
