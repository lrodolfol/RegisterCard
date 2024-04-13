namespace RegisterCard.Application.DTO.CreditCard;
public record EditCreditCard : BaseDto
{
    public string Number { get; set; } = null!;
    public short SecurityCode { get; set; }
    public void Validate()
    {
        if (string.IsNullOrEmpty(Number))
            _listNotifications.Add("Number can not be empty");
        if (Number.Trim().Length != 16)
            _listNotifications.Add("Number must have 16 caracters");
        if (SecurityCode <= 0)
            _listNotifications.Add("SecurityCode must be a valid Number");
        if (SecurityCode.ToString().Length != 4)
            _listNotifications.Add("SecurityCode must have 4 caracters");
    }

    public static implicit operator Core.Entities.CreditCard(EditCreditCard thisCreditCard)
        => new Core.Entities.CreditCard(thisCreditCard.Number, thisCreditCard.SecurityCode);
}
