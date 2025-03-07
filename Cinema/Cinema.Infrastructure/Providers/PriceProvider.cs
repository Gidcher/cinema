using Cinema.Data;
using Cinema.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Providers;

public class PriceProvider : IPriceProvider
{
    private readonly ApplicationContext _applicationContext;

    public PriceProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    public async Task<Guid> AddAsync(Price entity, CancellationToken cancellationToken)
    {
        // if (await _applicationContext.Employees.ContainsAsync(entity.Boss, cancellationToken))
        //     _applicationContext.Entry(entity.Boss).State = EntityState.Unchanged;
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task<Price?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Prices
            .Include(p => p.SeatType)
            .Include(p => p.Cost)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var price = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(price);
        _applicationContext.Remove(price);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Price> UpdateAsync(Price entity, CancellationToken cancellationToken)
    {
        _applicationContext.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<Price>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Prices
            .Include(p => p.SeatType)
            .Include(p => p.Cost)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}