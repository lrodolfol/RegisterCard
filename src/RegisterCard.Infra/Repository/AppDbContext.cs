using Microsoft.EntityFrameworkCore;
using RegisterCard.Core.Aggregates;
using RegisterCard.Core.Entities;
using RegisterCard.Infra.Repository.Mapping;

namespace RegisterCard.Infra.Repository;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {
    }

    public DbSet<Client> Client { get; set; } = null!;
    public DbSet<CreditCard> CreditCard { get; set; } = null!;
    public DbSet<Token> Token { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientMap());
        modelBuilder.ApplyConfiguration(new CreditCardMap());
        modelBuilder.ApplyConfiguration(new TokenMap());
    }
}
