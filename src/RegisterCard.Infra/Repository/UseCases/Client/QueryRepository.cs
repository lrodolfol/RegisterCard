using Microsoft.EntityFrameworkCore;
using RegisterCard.Core.UseCases.Contracts.Client;

namespace RegisterCard.Infra.Repository.UseCases.Client;
public class QueryRepository : IQueryRepository
{
    private readonly AppDbContext _context;

    public QueryRepository(AppDbContext context) =>
        (_context) = (context);

    public async Task<RegisterCard.Core.Entities.Client?> GetAsync(Guid id) =>
        await _context.Client
        .Include(client => client.CreditCards)
            .ThenInclude(token => token.Token)
        .AsNoTracking()
        .FirstOrDefaultAsync(client => client.Id == id);

    public List<RegisterCard.Core.Entities.Client> GetAsync() =>
        _context.Client
        .Include(client => client.CreditCards)
            .ThenInclude(token => token.Token)
        .AsTracking()
        .ToList();
}
