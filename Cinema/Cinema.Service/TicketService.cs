using AutoMapper;
using Cinema.Data;
using Cinema.Service.Interface;
using Cinema.Service.ModelsRequest;

namespace Cinema.Service;

public class TicketService:BaseService<Ticket,TicketRequest,ITicketProvider>, ITicketService
{
    private ITicketProvider _provider;
    private IMapper _mapper;
    public TicketService(ITicketProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }
}