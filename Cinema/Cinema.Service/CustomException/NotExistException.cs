namespace Cinema.Service.CustomException;

public class NotExistException:System.Exception
{
    public NotExistException(string? message) : base(message)
    {
    }
}