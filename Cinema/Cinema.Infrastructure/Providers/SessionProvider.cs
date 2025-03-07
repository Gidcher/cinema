using Cinema.Data;
using Cinema.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Providers;

public class SessionProvider : ISessionProvider
{
    private readonly ApplicationContext _applicationContext;

    public SessionProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    public async Task<Guid> AddAsync(Session entity, CancellationToken cancellationToken)
    {
        // if (await _applicationContext.Employees.ContainsAsync(entity.Boss, cancellationToken))
        //     _applicationContext.Entry(entity.Boss).State = EntityState.Unchanged;
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task<Session?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Sessions
            .Include(s => s.Movie)
            .Include(s => s.Hall)
            .Include(s => s.DateTime)
            .Include(s => s.Format)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var session = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(session);
        _applicationContext.Remove(session);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Session> UpdateAsync(Session entity, CancellationToken cancellationToken)
    {
        _applicationContext.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<Session>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Sessions
            .Include(s => s.Movie)
            .Include(s => s.Hall)
            .Include(s => s.DateTime)
            .Include(s => s.Format)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}