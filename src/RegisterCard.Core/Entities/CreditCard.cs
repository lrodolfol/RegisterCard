using RegisterCard.Core.Aggregates;

namespace RegisterCard.Core.Entities;

public class CreditCard : Entity
{
    public string Number { get; private set; } = null!;
    public short SecurityCode { get; private set; }
    public Guid ClientId { get; private set; }
    public Client? Client { get; set; }
    public Guid TokenId { get; set; }
    public Token? Token { get; private set; }

    public CreditCard(string number, short securityCode)
    {
        Number = number;
        SecurityCode = securityCode;
    }

    public void SetClientId(Guid clientId) =>
        ClientId = clientId;

    public void SetToken(Token token) =>
        Token = token;    
}