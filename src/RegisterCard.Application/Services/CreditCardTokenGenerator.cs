using RegisterCard.Core.Aggregates;
using RegisterCard.Core.Entities;

namespace RegisterCard.Application.Services;
public class CreditCardTokenGenerator
{
    public Token Generate(IGeneratorToken generator, CreditCard creditCard)
    {
        return generator.Generate(creditCard);
    }
}
