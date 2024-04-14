using Microsoft.EntityFrameworkCore;
using RegisterCard.Core.UseCases.Contracts.CreditCard;

namespace RegisterCard.Infra.Repository.UseCases.Account;
public class QueryRepository : IQueryRepository
{
    private readonly AppDbContext _context;

    public QueryRepository(AppDbContext context) =>
        (_context) = (context);

    public async Task<Core.Entities.CreditCard?> GetAsync(int id) =>
        await _context.CreditCard
            .FirstOrDefaultAsync(x => x.Id == id);    
}
