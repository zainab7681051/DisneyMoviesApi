using DisneyMoviesApi.Models;

namespace DisneyMoviesApi.Extensions;
public static class LessDetail
{
    public static MoviesWithLessDetail ToLessDetail(this DisneyMovie movie)
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