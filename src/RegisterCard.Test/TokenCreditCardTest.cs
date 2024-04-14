using RegisterCard.Application.Services;

namespace RegisterCard.Test;
public class TokenCreditCardTest
{
    [Theory]
    [InlineData("1234567891234567", 0001, "7456")]
    [InlineData("1234567891234567", 0002, "6745")]
    [InlineData("1234567891234567", 0003, "5674")]
    [InlineData("1234567891234567", 0004, "4567")]
    [InlineData("1234567891234567", 9999, "5674")]
    public void ShouldCreateAValidToken(string creditCardNumber, short securityCode, string expectedToken)
    {
        var generator = new CreditCardTokenGenerator();

        var token = generator.Generate(
            new BeloToken(),
            new Core.Entities.CreditCard(creditCardNumber, securityCode)
            );

        Assert.Equal(expectedToken, token.Number);
    }
}
