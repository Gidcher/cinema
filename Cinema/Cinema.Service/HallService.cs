using AutoMapper;
using Cinema.Data;
using Cinema.Service.Interface;
using Cinema.Service.ModelsRequest;

namespace Cinema.Service;

public class HallService:BaseService<Hall,HallRequest,IHallProvider>, IHallService
{
    private IHallProvider _provider;
    private IMapper _mapper;
    public HallService(IHallProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }
}