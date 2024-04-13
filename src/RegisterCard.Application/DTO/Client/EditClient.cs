using RegisterCard.Core.ValueObjects;

namespace RegisterCard.Application.DTO.Client;
public record EditClient : BaseDto
{
    public string Name { get; set; } = null!;
    public string Cpf { get; set; } = null!;

    public void Validate()
    {
        if (string.IsNullOrEmpty(Name))
            _listNotifications.Add("Name can not be empty");
        if (Name.Trim().Length < 3)
            _listNotifications.Add("Name must have 3 caracters");
        if (string.IsNullOrEmpty(Cpf))
            _listNotifications.Add("Cpfs can not be empty");
        if (Cpf.Trim().Length != 11)
            _listNotifications.Add("Name must have 11 caracters");
    }

    public static implicit operator Core.Entities.Client(EditClient thisClient)
        => new Core.Entities.Client()
        {
            Name = thisClient.Name,
            Cpf = new Cpf(thisClient.Cpf)
        };
}
