using Cinema.Data;

namespace Cinema.Service.ModelsRequest;

public class MovieRequest : BaseModelRequest
{
    public string Title { get; set; } 
    public string Description { get; set; } 
    public string Genre { get; set; } 
    public TimeSpan Duration { get; set; }
    public AgeRating  AgeRestriction { get; set; }
}