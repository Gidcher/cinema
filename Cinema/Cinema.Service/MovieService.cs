using AutoMapper;
using Cinema.Data;
using Cinema.Service.Interface;
using Cinema.Service.ModelsRequest;

namespace Cinema.Service;

public class MovieService:BaseService<Movie,MovieRequest,IMovieProvider>, IMovieService
{
    private IMovieProvider _provider;
    private IMapper _mapper;
    public MovieService(IMovieProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }

    public async Task<List<Movie>> GetMovieByTitle(string title, CancellationToken cancellationToken)
    {
        var movie = GetAllAsync(cancellationToken).Result.ToList().Where(m => m.Title == title).ToList();
        return movie;
    }
}