namespace Cinema.Data;

public class Ticket : BaseModel
{
    public Guid SessionId { get; set; }
    public Session Session { get; set; }
    public Guid SeatId { get; set; }
    public Seat Seat { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public decimal FinalPrice { get; set; }
}