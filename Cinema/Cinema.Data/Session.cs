namespace Cinema.Data;

public class Session : BaseModel
{
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public int HallId { get; set; }
    public Hall Hall { get; set; }
    public DateTime DateTime { get; set; }
    public string Format { get; set; } = "2D";
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();
}

