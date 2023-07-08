namespace DisneyMovieApi.Models
{
public class Movie
{
    public int MovieId { get; set; }
    public string? title { get; set; }
    public string? year { get; set; }
    public string? link { get; set; }
    public string? image { get; set; }
    public string? runtime { get; set; }
    public string? genre { get; set; }
    public string? summary { get; set; }
    public string? rating { get; set; }
    public string? metascore { get; set; }
    public string? directors { get; set; }
    public string? stars { get; set; }
}
}