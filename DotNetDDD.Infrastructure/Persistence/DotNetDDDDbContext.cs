using DotNetDDD.Domain.Aggregates.UserAggregate;
using DotNetDDD.Domain.Aggregates.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetDDD.Infrastructure.Persistence;

public class DotNetDDDDbContext : DbContext
{
    public DotNetDDDDbContext(DbContextOptions<DotNetDDDDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {

        options.UseSqlServer(
           "Data Source=localhost,1433;Initial Catalog=DotNetDDD;User ID=sa;Password=#admin@2456;MultipleActiveResultSets=True;TrustServerCertificate=True;"
        );

    }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var userIdConverter = new ValueConverter<UserId, Guid>(
            v => v.Value,
            a => a);

        modelBuilder.Entity<User>()
            .Property(e => e.Id)
            .HasConversion(userIdConverter);
    }
}
