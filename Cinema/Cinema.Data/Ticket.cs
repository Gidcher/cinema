namespace Cinema.Data;

public class Ticket : BaseModel
{
    public Session Session { get; set; } = null!;
    public HallSeats HallSeats { get; set; } = null!;
    public Price Price { get; set; } = null!;
}