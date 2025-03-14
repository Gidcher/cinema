namespace Cinema.Data;

public class Hall : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public List<Seat> Seats { get; set; } = new List<Seat>();
    public List<Session> Sessions { get; set; } = new List<Session>();
}