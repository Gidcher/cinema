namespace Cinema.Data;

public class Session : BaseModel
{
    public Movie Movie { get; set; }
    public Hall Hall { get; set; }
    public DateTime DateTime { get; set; }
    public string Format { get; set; } = "2D";
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();
}