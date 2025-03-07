using Cinema.Service.ModelsRequest;

namespace Cinema.Service.ModelsRequest;

public class TicketRequest : BaseModelRequest
{
    public Guid SessionId { get; set; }
    public Guid HallSeatsId { get; set; }
    public Guid PriceId { get; set; } 
}