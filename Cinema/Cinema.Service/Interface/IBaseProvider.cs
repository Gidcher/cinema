namespace Cinema.Service.Interface;

public interface IBaseProvider<TEntity>
{
    Task<Guid> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity?> FindAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
}