namespace Cinema.Data;

public class Movie : BaseModel
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public TimeSpan Duration { get; set; }
    public AgeRating  AgeRestriction { get; set; }
    public List<Session> Sessions { get; set; } = new List<Session>();
}