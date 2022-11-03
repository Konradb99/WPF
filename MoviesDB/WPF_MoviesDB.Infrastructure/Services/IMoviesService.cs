using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MoviesDB.Infrastructure.Models;

namespace WPF_MoviesDB.Infrastructure.Services
{
    public interface IMoviesService
    {
        public Task<IEnumerable<Movie>> GetMoviesPageByGenre(int genreId, int pageNumber);
    }
}
