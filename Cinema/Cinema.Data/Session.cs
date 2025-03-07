namespace Cinema.Data;

public class Session : BaseModel
{
    
    public Guid MovieId { get; set; }
    public Movie Movie { get; set; }
    public Hall Hall { get; set; }
    public DateTime DateTime { get; set; }
    public string Format { get; set; }
}