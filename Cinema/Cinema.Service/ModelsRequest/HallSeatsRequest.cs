using Cinema.Service.ModelsRequest;

namespace Cinema.Service.ModelsRequest;

public class HallSeatsRequest : BaseModelRequest
{
    public Guid PriceId { get; set; }
    public Guid HallId { get; set; }
    public int Number { get; set; }
}