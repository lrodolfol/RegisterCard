namespace RegisterCard.Core.UseCases.Contracts.Client;
public interface IQueryRepository
{
    Task<Entities.Client> GetAsync(Guid id);
    List<Entities.Client> GetAsync();
}
