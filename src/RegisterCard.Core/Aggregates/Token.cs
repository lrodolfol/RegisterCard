using RegisterCard.Core.Entities;

namespace RegisterCard.Core.Aggregates;
public class Token : Entity
{
    public string Number { get; private set; } = null!;

    public Token(string number) =>
        Number = number;    
}
