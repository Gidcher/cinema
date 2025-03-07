using Cinema.Data;
using Cinema.Service.ModelsRequest;

namespace Cinema.Service.Interface;

public interface IMovieService : IBaseService<Movie, MovieRequest>
{
    Task<List<Movie>> GetMovieByTitle(string title, CancellationToken cancellationToken);
}