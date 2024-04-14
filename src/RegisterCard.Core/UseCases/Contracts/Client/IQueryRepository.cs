namespace RegisterCard.Core.UseCases.Contracts.Client;
public interface IQueryRepository
{
    Task<Entities.Client> GetAsync(int id);
    List<Entities.Client> GetAsync();
}
