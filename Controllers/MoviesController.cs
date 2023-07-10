using DisneyMoviesApi.DatabaseContext;
using DisneyMoviesApi.Models;
using Microsoft.AspNetCore.Mvc;
using DisneyMoviesApi.Extensions;
using DisneyMoviesApi.DDos;

namespace DisneyMoviesApi.Controllers;
[ApiController]
[Route("/")]
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

    [HttpGet]
    public ActionResult<IEnumerable<MoviesWithLessDetail>> GetAllMovies()
    {
        ilogger.LogInformation("http get request return all movies");
        var movies = context.DisneyMovies.Select(e => e.ToLessDetailDDo()).ToList();
        if (movies is null) return NotFound();
        return movies;
    }
    [HttpGet("{id}")]
    public ActionResult<MoviesWithLessDetail> GetOneMovie(int id)
    {
        ilogger.LogInformation($"http get request return one movie with id: {id}");
        var movie = context.DisneyMovies.Find(id);
        if (movie is null) return NotFound();
        return movie.ToLessDetailDDo();
    }
    // [HttpGet("{query}")]
    // public ActionResult<IEnumerable<MoviesWithLessDetail>> SearchMovies(string query)
    // {
    //     ilogger.LogInformation($"http get request query movies with query: {query}");
    //     var movie = context.DisneyMovies.Where(e => e.Title!.Contains(query) || e.Year.Contains(query) || e.MovieId.ToString().Contains(query))
    //     .Select(e => e.ToLessDetailDDo()).ToList();
    //     if (movie is null ) return NotFound();
    //     return movie;
    // }
}