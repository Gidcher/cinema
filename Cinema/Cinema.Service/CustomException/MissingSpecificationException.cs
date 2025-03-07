namespace Cinema.Service.CustomException;

public class MissingSpecificationException: System.Exception
{
    public MissingSpecificationException(string? message) : base(message)
    {
    }
}