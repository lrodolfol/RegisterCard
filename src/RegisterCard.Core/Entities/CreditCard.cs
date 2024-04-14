using RegisterCard.Core.Aggregates;

namespace RegisterCard.Core.Entities;

public class CreditCard : Entity
{
    public string Number { get; private set; } = null!;
    public short SecurityCode { get; private set; }
    public int ClientId { get; private set; }
    public Client? Client { get; set; }
    public int TokenId { get; set; }
    public Token? Token { get; private set; }

    public CreditCard(string number, short securityCode)
    {
        Number = number;
        SecurityCode = securityCode;
    }

    public void SetClientId(int clientId) =>
        ClientId = clientId;

    public void SetToken(Token token) =>
        Token = token;    
}