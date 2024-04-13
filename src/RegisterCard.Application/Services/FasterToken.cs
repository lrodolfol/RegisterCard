using RegisterCard.Core.Aggregates;
using RegisterCard.Core.Entities;
using System.Security.Cryptography;

namespace RegisterCard.Application.Services;
public class FasterToken : IGeneratorToken
{
    public Token Generate(CreditCard creditCard)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(creditCard.Number + creditCard.SecurityCode);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            var str = Convert.ToHexString(hashBytes);

            return new Token(str);
        }
    }
}
