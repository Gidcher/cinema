using Cinema.Service.ModelsRequest;

namespace Cinema.Service.ModelsRequest;

public class SessionRequest : BaseModelRequest
{
    public Guid MovieId { get; set; }
    public Guid HallId { get; set; }
    public DateTime DateTime { get; set; }
    public string Format { get; set; }
}