using Cinema.Data;
using Cinema.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Providers;

public class HallProvider : IHallProvider
{
    private readonly ApplicationContext _applicationContext;

    public HallProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    public async Task<Guid> AddAsync(Hall entity, CancellationToken cancellationToken)
    {
        // if (await _applicationContext.Employees.ContainsAsync(entity.Boss, cancellationToken))
        //     _applicationContext.Entry(entity.Boss).State = EntityState.Unchanged;
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task<Hall?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Halls
            .Include(h => h.Name)
            .Include(h => h.Seats)
            .Include(h => h.Sessions)
            .FirstOrDefaultAsync(h => h.Id == id, cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var hall = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(hall);
        _applicationContext.Remove(hall);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Hall> UpdateAsync(Hall entity, CancellationToken cancellationToken)
    {
        _applicationContext.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<Hall>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Halls
            .Include(h => h.Name)
            .Include(h =>h.Seats)
            .Include(h => h.Sessions)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}