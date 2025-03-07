using Cinema.Data;
using Cinema.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Providers;

public class MovieProvider : IMovieProvider
{
    private readonly ApplicationContext _applicationContext;

    public MovieProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    public async Task<Guid> AddAsync(Movie entity, CancellationToken cancellationToken)
    {
        // if (await _applicationContext.Employees.ContainsAsync(entity.Boss, cancellationToken))
        //     _applicationContext.Entry(entity.Boss).State = EntityState.Unchanged;
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task<Movie?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Movies
            .Include(m => m.Title)
            .Include(m => m.Description)
            .Include(m => m.Genre)
            .Include(m => m.Duration)
            .Include(m => m.AgeRestriction)
            .Include(m => m.Sessions)
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var movie = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(movie);
        _applicationContext.Remove(movie);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Movie> UpdateAsync(Movie entity, CancellationToken cancellationToken)
    {
        _applicationContext.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<Movie>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Movies
            .Include(m => m.Title)
            .Include(m => m.Description)
            .Include(m => m.Genre)
            .Include(m => m.Duration)
            .Include(m => m.AgeRestriction)
            .Include(m => m.Sessions)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}