using DisneyMoviesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DisneyMoviesApi.DatabaseContext;

public partial class DisneyMoviesDbContext : DbContext
{
    public DisneyMoviesDbContext()
    {
    }

    public DisneyMoviesDbContext(DbContextOptions<DisneyMoviesDbContext> options) : base(options)
    {
    }

    public virtual DbSet<DisneyMovie> DisneyMovies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Name=ConnectionStrings:DisneyMoviesDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DisneyMovie>(entity =>
        {
            entity.HasKey(e => e.MovieId);

            entity.ToTable("disney_movies");

            entity.Property(e => e.Directors).HasColumnName("directors");
            entity.Property(e => e.Genre).HasColumnName("genre");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Link).HasColumnName("link");
            entity.Property(e => e.Metascore).HasColumnName("metascore");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Runtime).HasColumnName("runtime");
            entity.Property(e => e.Stars).HasColumnName("stars");
            entity.Property(e => e.Summary).HasColumnName("summary");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
