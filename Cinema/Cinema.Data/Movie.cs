namespace Cinema.Data;

public class Movie : BaseModel
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TimeSpan Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Country { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Screenplay { get; set; } = string.Empty;
    public string Cast { get; set; } = string.Empty;
    public AgeRating AgeRestriction { get; set; }
    public string TrailerUrl { get; set; } = string.Empty;
    public List<Session> Sessions { get; set; } = new List<Session>();
}
