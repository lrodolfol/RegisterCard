namespace RegisterCard.Core.UseCases.Contracts.Client;
public interface ICommandRepository
{
    Task CreateAsync(Entities.Client client);
}
