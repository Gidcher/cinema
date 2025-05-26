using Cinema.Data;
using Cinema.Service.Interface;
using Cinema.Service.ModelsRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cinema.Api.Controllers;

/// <summary>
/// Контроллер для управления фильмами.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MovieController : WebApiController
{
    private readonly IMovieService _movieService;
    private readonly ILogger<MovieController> _logger;

    public MovieController(IMovieService movieService, ILogger<MovieController> logger)
    {
        _movieService = movieService;
        _logger = logger;
    }

    /// <summary>
    /// Получает список всех фильмов.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список фильмов.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Movie>), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var movies = await _movieService.GetAllAsync(cancellationToken);
        return Ok(movies);
    }

    /// <summary>
    /// Получает фильм по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор фильма.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Фильм.</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Movie), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 404)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var movie = await _movieService.GetAsync(id, cancellationToken); // используем базовый GetAsync
        if (movie == null)
            return NotFound();
        return Ok(movie);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Movie), 201)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IActionResult> Create([FromBody] MovieRequest model, CancellationToken cancellationToken = default)
    {
        var createdId = await _movieService.CreateAsync(model, cancellationToken);
        var created = await _movieService.GetAsync(createdId, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = createdId }, created);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Movie), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 404)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IActionResult> Update(Guid id, [FromBody] MovieRequest model, CancellationToken cancellationToken = default)
    {
        model.Id = id; // предполагается, что MovieRequest содержит Id
        var updated = await _movieService.UpdateAsync(model, cancellationToken);
        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ProblemDetails), 404)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _movieService.DeleteAsync(id, cancellationToken);
        if (!result)
            return NotFound();
        return NoContent();
    }

}
