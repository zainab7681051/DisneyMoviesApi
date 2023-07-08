using DisneyMovieApi.Models;
using Microsoft.EntityFrameworkCore;
namespace DisneyMovieApi.DatabaseContext
{
public class SqliteDbContext : DbContext
{
    public DbSet<Movie>? disney_movies { get; set; }
    public string DbPath { get; }

    public SqliteDbContext()
    {
        DbPath = "../Database/DisneyMoviesDB.db";
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");
}
}