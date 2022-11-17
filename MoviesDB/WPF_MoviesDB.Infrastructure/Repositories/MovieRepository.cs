using Dapper;
using System.Data;
using System.Data.SqlClient;
using WPF_MoviesDB.Infrastructure.DatabaseEntities;

namespace WPF_MoviesDB.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private const string _connectionString = "Data Source=.; Initial Catalog=MoviesDB; Integrated Security=True";
        public void AddMovieToFavourites(MovieEntity movie)
        {
            string sqlRequest = "INSERT INTO favourite_movies (title, release_date, vote, overview, backdrop_path, poster_path) VALUES";
            string sqlParams = "(@title, @release_date, @vote, @overview, @backdrop_path, @poster_path)";

            var dynamicParams = new DynamicParameters();
            dynamicParams.Add("title", movie.title);
            dynamicParams.Add("release_date", movie.release_date);
            dynamicParams.Add("vote", movie.vote);
            dynamicParams.Add("overview", movie.overview);
            dynamicParams.Add("backdrop_path", movie.backdrop_path);
            dynamicParams.Add("poster_path", movie.poster_path);

            string sql = $"{sqlRequest}{sqlParams}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, dynamicParams);
            }
        }
    }
}
