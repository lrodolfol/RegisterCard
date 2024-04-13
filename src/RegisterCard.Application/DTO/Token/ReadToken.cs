namespace RegisterCard.Application.DTO.Token;
public record ReadToken
{
    public string Number { get; set; } = null!;

    public ReadToken(string number)
    {
        Number = number;
    }
}
