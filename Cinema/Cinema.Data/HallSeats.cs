namespace Cinema.Data;

public class HallSeats : BaseModel
{
    public Price Price { get; set; }
    public Hall Hall { get; set; }
    public int Number { get; set; }
}