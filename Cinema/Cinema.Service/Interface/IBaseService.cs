using Cinema.Data;
using Cinema.Service.ModelsRequest;

namespace Cinema.Service.Interface;

public interface IBaseService<TEntityDb, TEntityRequest>
    where TEntityDb: BaseModel
    where TEntityRequest: BaseModelRequest
{
    Task<Guid> CreateAsync(TEntityRequest entityRequest, CancellationToken cancellationToken);
    Task<TEntityDb?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<TEntityDb> UpdateAsync(TEntityRequest entityRequest, CancellationToken cancellationToken);
    Task<List<TEntityDb>> GetAllAsync(CancellationToken cancellationToken);
}