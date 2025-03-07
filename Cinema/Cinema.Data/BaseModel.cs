namespace Cinema.Data;

public class BaseModel
{
    public Guid Id { get; set; }
    public DateTime DataCreate { get; set; }
    public DateTime DataUpdate { get; set; }

    public BaseModel()
    {
        Id = Guid.NewGuid();
        DataCreate = DateTime.Now;
        DataUpdate = DateTime.Now;
    }
}