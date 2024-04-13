using RegisterCard.Application.DTO.Token;

namespace RegisterCard.Application.DTO.CreditCard;
public record ReadCreditCard
{
    public string Number { get; set; } = null!;
    public ReadToken Token { get; set; } = null!;
    public ReadCreditCard(string number, ReadToken token)
    {
        Number = number;
        Token = token;
    }
}
