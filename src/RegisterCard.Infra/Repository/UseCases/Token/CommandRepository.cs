using RegisterCard.Core.UseCases.Contracts.Token;

namespace RegisterCard.Infra.Repository.UseCases.Token;
public class CommandRepository : ICommandRepository
{
    private readonly AppDbContext _context;

    public CommandRepository(AppDbContext context) =>
        (_context) = (context);

    public async Task CreateAsync(Core.Aggregates.Token token)
    {
        await _context.AddAsync(token);
        await _context.SaveChangesAsync();
    }
}
