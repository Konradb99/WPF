﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WPF_MoviesDB.Core.Constants;
using WPF_MoviesDB.Infrastructure.Models;

namespace WPF_MoviesDB.Infrastructure.Services
{
    public class GenresService : IGenresService
    {
        private HttpClient _httpClient = new HttpClient();

        public async Task<ICollection<Genre>> GetGenres()
        {
            string apiUrl = $"{ApiConstants.baseUrl}{ApiConstants.genresUri}?api_key={ApiConstants.apiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            GenreList genreList = JsonConvert.DeserializeObject<GenreList>(result);
            ICollection<Genre> genres = new List<Genre>();
            foreach (var genre in genreList.genres)
            {
                genres.Add(genre);
            }
             
            return genres;
        }
    }
}
