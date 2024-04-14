using Microsoft.EntityFrameworkCore;
using RegisterCard.Core.UseCases.Contracts.Token;

namespace RegisterCard.Infra.Repository.UseCases.Token;
public class QueryRepository : IQueryRepository
{
    private readonly AppDbContext _context;

    public QueryRepository(AppDbContext context) =>
        (_context) = (context);

    public async Task<Core.Aggregates.Token?> GetAsync(int id) =>
        await _context.Token
        .FirstOrDefaultAsync(x => x.Id == id);
}
