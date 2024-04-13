using RegisterCard.Core.Aggregates;
using RegisterCard.Core.Entities;

namespace RegisterCard.Application.Services;
public class BeloToken : IGeneratorToken
{
    public Token Generate(CreditCard creditCard)
    {
        int lastFour = int.Parse(creditCard.Number.Substring(creditCard.Number.Length - 4));

        short[] result = new short[4];
        var resultStr = lastFour.ToString();

        for (int i = 0; i < creditCard.SecurityCode; i++)
        {
            resultStr = Run(resultStr);
        }

        return new Token(resultStr);
    }

    private string Run(string number)
    {
        var newNumber = $"{number[3]}{number[0]}{number[1]}{number[2]}";
        return newNumber;
    }
}
