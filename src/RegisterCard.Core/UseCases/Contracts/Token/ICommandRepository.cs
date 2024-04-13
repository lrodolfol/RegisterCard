namespace RegisterCard.Core.UseCases.Contracts.Token;
public interface ICommandRepository
{
    Task CreateAsync(Aggregates.Token token);
}
