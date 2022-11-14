using WPF_MoviesDB.Infrastructure.Models;

namespace WPF_MoviesDB.Infrastructure.Services
{
    public interface IMoviesService
    {
        public Task<IEnumerable<Movie>> GetMoviesPageByGenre(int genreId, int pageNumber);

        public Task<IEnumerable<Movie>> GetMoviesPage();
    }
}