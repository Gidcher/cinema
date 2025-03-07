namespace Cinema.Service.CustomException;

public class MissingDivisionException: System.Exception
{
    public MissingDivisionException(string? message) : base(message)
    {
    }
}