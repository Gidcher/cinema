using Cinema.Data;
using Cinema.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Providers;

public class TicketProvider : ITicketProvider
{
    private readonly ApplicationContext _applicationContext;

    public TicketProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    public async Task<Guid> AddAsync(Ticket entity, CancellationToken cancellationToken)
    {
        // if (await _applicationContext.Employees.ContainsAsync(entity.Boss, cancellationToken))
        //     _applicationContext.Entry(entity.Boss).State = EntityState.Unchanged;
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task<Ticket?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Tickets
            .Include(t => t.Session)
            .Include(t => t.HallSeats)
            .Include(t => t.Price)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken).ConfigureAwait(false);

    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var ticket = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(ticket);
        _applicationContext.Remove(ticket);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Ticket> UpdateAsync(Ticket entity, CancellationToken cancellationToken)
    {
        _applicationContext.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<Ticket>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Tickets
            .Include(t => t.Session)
            .Include(t => t.HallSeats)
            .Include(t => t.Price)
            .ToListAsync(cancellationToken: cancellationToken);

    }
}