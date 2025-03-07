using Cinema.Data;
using Cinema.Service.ModelsRequest;

namespace Cinema.Service.Interface;

public interface IHallSeatsService : IBaseService<HallSeats, HallSeatsRequest>
{
    Task<List<HallSeats>> GetAllHallSeats(Guid hallId, CancellationToken cancellationToken);
    Task<List<HallSeats>> GetAllVipHallSeats(Guid hallId, Guid price, CancellationToken cancellationToken);
}