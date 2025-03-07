namespace Cinema.Data;

public class Price : BaseModel
{
    public string SeatType { get; set; } = string.Empty;
    public decimal Cost { get; set; }
}