namespace RegisterCard.Core.UseCases.Contracts.CreditCard;
public interface IQueryRepository
{
    public Task<RegisterCard.Core.Entities.CreditCard> GetAsync(int id);
}
