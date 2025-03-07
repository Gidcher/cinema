namespace Cinema.Data;

public class Hall : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public List<HallSeats> Seats { get; set; } = new List<HallSeats>();
    public List<Session> Sessions { get; set; } = new List<Session>();
}