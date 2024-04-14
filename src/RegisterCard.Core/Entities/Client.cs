using RegisterCard.Core.ValueObjects;

namespace RegisterCard.Core.Entities;
public class Client : Entity
{
    public string Name { get; set; } = null!;
    public Cpf Cpf { get; set; } = null!;
    public int CreditCardId { get; set; }
    public List<CreditCard>? CreditCards { get; set; } = null!;

    //public Client(string name, Cpf cpf)
    //{
    //    Name = name;
    //    Cpf = cpf;
    //}
}
