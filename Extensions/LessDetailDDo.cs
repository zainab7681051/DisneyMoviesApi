using DisneyMoviesApi.DDos;
using DisneyMoviesApi.Models;

namespace DisneyMoviesApi.Extensions;
public static class LessDetailDDo
{
    public static MoviesWithLessDetail ToLessDetailDDo(this DisneyMovie movie)
    {
        var Nmovie = new MoviesWithLessDetail()
        {
            MovieId = movie.MovieId,
            Title = movie.Title,
            Year = movie.Year,
            Image = movie.Image,
            Rating = movie.Rating,
        };
        return Nmovie;
    }
}