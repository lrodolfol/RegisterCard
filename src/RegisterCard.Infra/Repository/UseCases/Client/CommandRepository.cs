using RegisterCard.Core.UseCases.Contracts.Client;

namespace RegisterCard.Infra.Repository.UseCases.Client;
public class CommandRepository : ICommandRepository
{
    private readonly AppDbContext _context;

    public CommandRepository(AppDbContext context) =>
        (_context) = (context);

    public async Task CreateAsync(Core.Entities.Client client)
    {
        await _context.Client.AddAsync(client);
        await _context.SaveChangesAsync();
    }
}
