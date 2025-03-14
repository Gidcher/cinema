namespace Cinema.Data;

public class Ticket : BaseModel
{
    public Session Session { get; set; }
    public Seat Seat { get; set; }
    public User User { get; set; }
    public decimal FinalPrice { get; set; }
}