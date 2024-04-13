using RegisterCard.Core.UseCases.Contracts.CreditCard;

namespace RegisterCard.Infra.Repository.UseCases.Account;
public class CommandRepository : ICommandRepository
{
    private readonly AppDbContext _context;

    public CommandRepository(AppDbContext context) =>
        (_context) = (context);

    public async Task CreateAsync(Core.Entities.CreditCard creditCard)
    {
        await _context.CreditCard.AddAsync(creditCard);
        await _context.SaveChangesAsync();
    }
}
