using AutoMapper;
using Cinema.Data;
using Cinema.Service.Interface;
using Cinema.Service.ModelsRequest;

namespace Cinema.Service;

public class SessionService:BaseService<Session,SessionRequest,ISessionProvider>, ISessionService
{
    private ISessionProvider _provider;
    private IMapper _mapper;
    public SessionService(ISessionProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }

    public async Task<List<Session>> GetSessionByDate(DateTime dateTime, CancellationToken cancellationToken)
    {
        var sessions = GetAllAsync(cancellationToken).Result.ToList().Where(s => s.DateTime == dateTime).ToList();
        return sessions;
    }
}