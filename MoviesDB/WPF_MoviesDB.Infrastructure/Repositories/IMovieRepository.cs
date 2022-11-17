using WPF_MoviesDB.Infrastructure.DatabaseEntities;

namespace WPF_MoviesDB.Infrastructure.Repositories
{
    public interface IMovieRepository
    {
        public void AddMovieToFavourites(MovieEntity movie);
    }
}
