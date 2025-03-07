using Cinema.Service.ModelsRequest;

namespace Cinema.Service.ModelsRequest;

public class PriceRequest : BaseModelRequest
{
    public string SeatType { get; set; }
    public decimal Cost { get; set; }
}