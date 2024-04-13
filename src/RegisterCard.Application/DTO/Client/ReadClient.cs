using RegisterCard.Application.DTO.CreditCard;

namespace RegisterCard.Application.DTO.Client;
public record ReadClient
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public List<ReadCreditCard> CreditCards { get; set; } = new();

    public ReadClient()
    {
    }

    public ReadClient(Core.Entities.Client client)
    {
        Id = client.Id;
        Name = client.Name;
        Cpf = client.Cpf.Number;
        client.CreditCards?.ForEach(c =>
        {
            CreditCards.Add(
                new ReadCreditCard(c.Number,
                new Token.ReadToken(c.Token.Number)
            ));
        });
    }
}
