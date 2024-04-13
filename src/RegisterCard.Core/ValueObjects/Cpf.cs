using RegisterCard.Core.Exceptions;

namespace RegisterCard.Core.ValueObjects;
public class Cpf
{
    public string Number { get; set; } = null!;
    public Cpf(string number)
    {
        Number = number;
        ExceptionIfIsInvalid();
    }

    public void ExceptionIfIsInvalid()
    {
        if (!Validate())
            throw new InvalidCpfException("The cpf number is invalid");
    }

    private bool Validate()
    {
        var autoCpf = CpfHelper.CalculateSecondDigit(
            CpfHelper.CalculateFirstDigit(Number.Substring(0, 9))
            );

        return autoCpf == Number;
    }
}

public class CpfHelper
{
    public static string CalculateFirstDigit(string cpf9Digits)
    {
        var sum = 0;
        var mult = 10;

        foreach (char c in cpf9Digits)
        {
            sum += int.Parse(c.ToString()) * mult;
            mult--;
        }

        if (sum % 11 <= 1)
            return cpf9Digits + "0";

        return cpf9Digits + (11 - (sum % 11)).ToString();
    }

    public static string CalculateSecondDigit(string cpf10Digits)
    {
        var sum = 0;
        var mult = 11;

        foreach (char c in cpf10Digits)
        {
            sum += int.Parse(c.ToString()) * mult;
            mult--;
        }

        if (sum % 11 <= 1)
            return cpf10Digits + "0";

        return cpf10Digits + (11 - (sum % 11)).ToString();
    }
}

