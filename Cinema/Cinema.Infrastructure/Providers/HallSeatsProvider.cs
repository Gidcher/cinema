using Cinema.Data;
using Cinema.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Providers;

public class HallSeatsProvider : IHallSeatsProvider
{
    private readonly ApplicationContext _applicationContext;

    public HallSeatsProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    public async Task<Guid> AddAsync(HallSeats entity, CancellationToken cancellationToken)
    {
        // if (await _applicationContext.Employees.ContainsAsync(entity.Boss, cancellationToken))
        //     _applicationContext.Entry(entity.Boss).State = EntityState.Unchanged;
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task<HallSeats?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Seats
            .Include(s => s.Price)
            .Include(s => s.Hall)
            .Include(s => s.Number)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken).ConfigureAwait(false);

    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var seats = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(seats);
        _applicationContext.Remove(seats);
        await _applicationContext.SaveChangesAsync(cancellationToken);

    }

    public async Task<HallSeats> UpdateAsync(HallSeats entity, CancellationToken cancellationToken)
    {
        _applicationContext.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<HallSeats>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Seats
            .Include(s => s.Price)
            .Include(s => s.Hall)
            .Include(s => s.Number)
            .ToListAsync(cancellationToken: cancellationToken);

    }
}