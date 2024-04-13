using RegisterCard.Core.Aggregates;
using RegisterCard.Core.Entities;

namespace RegisterCard.Application.Services;

public interface IGeneratorToken
{
    public Token Generate(CreditCard creditCard);
}