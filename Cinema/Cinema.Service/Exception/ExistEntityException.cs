namespace Cinema.Service.Exception;

public class ExistEntityException : System.Exception
{
    public ExistEntityException(string? message) : base(message)
    {
    }
}