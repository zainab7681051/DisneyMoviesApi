using DisneyMoviesApi.DatabaseContext;
using DisneyMoviesApi.Extensions;
using DisneyMoviesApi.Models;
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

    [HttpGet("/api/v1/movies")]
    public ActionResult<IEnumerable<MoviesWithLessDetail>> GetMoviesWithLessDetail()
    {
        ilogger.LogInformation("http get request return all movies");
        var movies = context.DisneyMovies.Select(e => e.ToLessDetail()).ToList();
        if (movies is null) return NotFound();
        return movies;
    }

    [HttpGet("/api/v1/movies/all")]
    public ActionResult<IEnumerable<DisneyMovie>> GetMovies()
    {
        ilogger.LogInformation("http get request return all movies");
        var movies = context.DisneyMovies.ToList();
        if (movies is null) return NotFound();
        return movies;
    }

    [HttpGet("/api/v1/movies/{id}")]
    public ActionResult<MoviesWithLessDetail> GetOneMovie(int id)
    {
        ilogger.LogInformation($"http get request return one movie with id: {id}");
        var movie = context.DisneyMovies.Find(id);
        if (movie is null) return NotFound();
        return movie.ToLessDetail();
    }

    [HttpGet("/api/v1/movies/all/{id}")]
    public ActionResult<DisneyMovie> GetOneMovieWithDetail(int id)
    {
        ilogger.LogInformation($"http get request return one movie with id: {id}");
        var movie = context.DisneyMovies.Find(id);
        if (movie is null) return NotFound();
        return movie;
    }

    [HttpGet("/api/v1/search")]
    public ActionResult<IEnumerable<MoviesWithLessDetail>> SearchMovies([FromQuery] string query = "")
    {
        ilogger.LogInformation($"http get request query movies with query: {query}");
        var qMovies = context.DisneyMovies.Where(e => e.Title!.Contains(query) || e.Year.Contains(query) || e.MovieId.ToString().Contains(query))
        .Select(e => e.ToLessDetail()).ToList();
        if (qMovies is null || !qMovies.Any()) return NotFound();
        return qMovies;
    }
}
