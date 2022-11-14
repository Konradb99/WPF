using WPF_MoviesDB.Infrastructure.Models;

namespace WPF_MoviesDB.Infrastructure.Services
{
    public interface IGenresService
    {
        public Task<ICollection<Genre>> GetGenres();
    }
}