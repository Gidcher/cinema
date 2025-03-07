using Cinema.Data;
using Cinema.Service.ModelsRequest;

namespace Cinema.Service.Interface;

public interface ISessionService : IBaseService<Session, SessionRequest>
{
    Task<List<Session>> GetSessionByDate(DateTime dateTime, CancellationToken cancellationToken);
}