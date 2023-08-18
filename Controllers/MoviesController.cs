using DisneyMoviesApi.DatabaseContext;
using DisneyMoviesApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DisneyMoviesApi.Controllers;
[ApiController]
[Route("/api/v1")]
public class MoviesController : ControllerBase
{
    private readonly DisneyMoviesDbContext context;
    private readonly ILogger<MoviesController> ilogger;
    public MoviesController(DisneyMoviesDbContext _context,
    ILogger<MoviesController> _ilogger)
    {
        context = _context;
        ilogger = _ilogger;
    }

    [HttpGet("/api/v1/movies/all")]
    public ActionResult GetMovies([FromQuery] bool details = false)
    {
        ilogger.LogInformation("http get request return all movies");
        if (details)
        {
            var movies = context.DisneyMovies.ToList();
            if (movies is null) return NotFound();
            return Ok(movies);
        }
        else
        {
            var movies = context.DisneyMovies.Select(e => e.ToLessDetail()).ToList();
            if (movies is null) return NotFound();
            return Ok(movies);
        }
    }

    [HttpGet("/api/v1/movies/{id}")]
    public ActionResult GetOneMovie(int id, [FromQuery] bool details = false)
    {
        ilogger.LogInformation($"http get request return one movie with id: {id}");
        if (details)
        {
            var movie = context.DisneyMovies.Find(id);
            if (movie is null) return NotFound();
            return Ok(movie);
        }
        else
        {
            var movie = context.DisneyMovies.Find(id);
            if (movie is null) return NotFound();
            return Ok(movie.ToLessDetail());
        }
    }

    [HttpGet("/api/v1/search")]
    public ActionResult SearchMovies([FromQuery] string query = "")
    {
        ilogger.LogInformation($"http get request query movies with query: {query}");
        var qMovies = context.DisneyMovies.Where(e => e.Title!.Contains(query) || e.Year!.Contains(query) || e.MovieId.ToString().Contains(query))
        .Select(e => e.ToLessDetail()).ToList();
        if (qMovies is null || !qMovies.Any()) return NotFound();
        return Ok(qMovies);
    }
}
