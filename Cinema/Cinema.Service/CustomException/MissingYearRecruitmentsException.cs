namespace Cinema.Service.CustomException;

public class MissingYearRecruitmentsException: System.Exception
{
    public MissingYearRecruitmentsException(string? message) : base(message)
    {
    }
}