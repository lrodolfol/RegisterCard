namespace RegisterCard.Core.UseCases.Contracts.Token;
public interface IQueryRepository
{
    Task<Aggregates.Token> GetAsync(Guid id);
}
