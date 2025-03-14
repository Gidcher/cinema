namespace Cinema.Data;

public class Seat : BaseModel
{
    public int SeatNumber { get; set; }
    public string SeatType { get; set; } = "Regular";
    public decimal Price { get; set; }
}