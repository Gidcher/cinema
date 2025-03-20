namespace Cinema.Data;

public class Ticket : BaseModel
{
    public int SessionId { get; set; }
    public Session Session { get; set; }
    public int SeatId { get; set; }
    public Seat Seat { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public decimal FinalPrice { get; set; }
}