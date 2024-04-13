namespace RegisterCard.Core.Exceptions;
public class InvalidCpfException : Exception
{
    public InvalidCpfException(string exception = "The cpf number is invalid")
    : base(exception)
    {
    }
}
