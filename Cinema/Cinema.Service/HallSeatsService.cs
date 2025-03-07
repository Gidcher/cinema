using AutoMapper;
using Cinema.Data;
using Cinema.Service.Interface;
using Cinema.Service.ModelsRequest;

namespace Cinema.Service;

public class HallSeatsService:BaseService<HallSeats,HallSeatsRequest,IHallSeatsProvider>, IHallSeatsService
{
    private IHallProvider _hallProvider;
    private IHallSeatsProvider _provider;
    private IMapper _mapper;
    public HallSeatsService(IHallSeatsProvider provider, IHallProvider hallProvider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
        _hallProvider = hallProvider;
    }

    public async Task<List<HallSeats>> GetAllHallSeats(Guid hallId, CancellationToken cancellationToken)
    {
        var hallSeats = GetAllAsync(cancellationToken).Result.ToList().Where(hs => hs.Hall.Id == hallId).ToList();
        return hallSeats;
    }

    public async Task<List<HallSeats>> GetAllVipHallSeats(Guid hallId, Guid price, CancellationToken cancellationToken)
    {
        var hallSeats = GetAllAsync(cancellationToken).Result.ToList().Where(hs => hs.Hall.Id == hallId && hs.Price.Id == price).ToList();
        return hallSeats;
    }
}