namespace Cinema.Data;

public class User : BaseModel
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Card { get; set; } = string.Empty; 
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();
}