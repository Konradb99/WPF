using Newtonsoft.Json;
using WPF_MoviesDB.Core.Constants;
using WPF_MoviesDB.Infrastructure.Models;

namespace WPF_MoviesDB.Infrastructure.Services
{
    public class MoviesService : IMoviesService
    {
        private HttpClient _httpClient = new HttpClient();

        public async Task<IEnumerable<Movie>> GetMoviesPage()
        {
            string apiUrl = $"{ApiConstants.baseUrl}{ApiConstants.moviesByGenreUri}?api_key={ApiConstants.apiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            MoviePage moviesList = JsonConvert.DeserializeObject<MoviePage>(result);
            foreach (var movie in moviesList.results)
            {
                movie.backdrop_path = ApiConstants.imageUrl + movie.backdrop_path;
                movie.poster_path = ApiConstants.imageUrl + movie.poster_path;
            }
            return moviesList.results;
        }

        public async Task<IEnumerable<Movie>> GetMoviesPageByGenre(int genreId, int pageNumber)
        {
            string apiUrl = $"{ApiConstants.baseUrl}{ApiConstants.moviesByGenreUri}?api_key={ApiConstants.apiKey}&page={pageNumber}&with_genres={genreId}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            MoviePage moviesList = JsonConvert.DeserializeObject<MoviePage>(result);
            foreach (var movie in moviesList.results)
            {
                movie.backdrop_path = ApiConstants.imageUrl + movie.backdrop_path;
                movie.poster_path = ApiConstants.imageUrl + movie.poster_path;
            }
            return moviesList.results;
        }
    }
}