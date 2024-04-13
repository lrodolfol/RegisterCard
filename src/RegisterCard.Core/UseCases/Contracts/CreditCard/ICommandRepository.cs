namespace RegisterCard.Core.UseCases.Contracts.CreditCard;
public interface ICommandRepository
{
    Task CreateAsync(Entities.CreditCard creditCard);
}
