namespace DisneyMoviesApi.Models;

public class DisneyMovie
{
    public int MovieId { get; set; }

    public string? Title { get; set; }

    public string? Year { get; set; }

    public string? Link { get; set; }

    public string? Image { get; set; }

    public string? Runtime { get; set; }

    public string? Genre { get; set; }

    public string? Summary { get; set; }

    public string? Rating { get; set; }

    public string? Metascore { get; set; }

    public string? Directors { get; set; }

    public string? Stars { get; set; }
}
public class MoviesWithLessDetail
{
    public int MovieId { get; set; }

    public string? Title { get; set; }

    public string? Year { get; set; }

    public string? Image { get; set; }

    public string? Rating { get; set; }

}
