using AutoMapper;
using Cinema.Data;
using Cinema.Service.Interface;
using Cinema.Service.ModelsRequest;

namespace Cinema.Service;

public class PriceService:BaseService<Price,PriceRequest,IPriceProvider>, IPriceService
{
    private IPriceProvider _provider;
    private IMapper _mapper;
    public PriceService(IPriceProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }
}