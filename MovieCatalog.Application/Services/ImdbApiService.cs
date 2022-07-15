using Microsoft.Extensions.Configuration;
using MovieCatalog.Application.Interfaces;
using MovieCatalog.Application.Models;
using MovieCollection.OpenMovieDatabase;
using MovieCollection.OpenMovieDatabase.Enums;
using MovieCollection.OpenMovieDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Application.Services
{
    public class ImdbApiService : IImdbApiService
    {
        private readonly IConfiguration configuration;
        private readonly HttpClient httpClient = new HttpClient();

        public ImdbApiService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public OpenMovieDatabaseService GetObjectOpenMovieDatabase()
        {
            var options = new OpenMovieDatabaseOptions(configuration["OMDbApiKey"]);
            var service = new OpenMovieDatabaseService(httpClient, options);

            return new OpenMovieDatabaseService(httpClient, options);
        }

        public async Task<ShortMovieModel[]> GetMoviesByTitle(string movieTitle)
        {
            var moviesByWord = await GetObjectOpenMovieDatabase().SearchMoviesAsync(movieTitle, "", SearchType.Movie);

            if (!moviesByWord.IsSuccess)
            {
                throw new Exception("Ошибка получения фильмов");
            }

            var resultList = new List<ShortMovieModel>();

            foreach (var movie in moviesByWord.Items)
            {
                var movieInfoByTitle = await SearchMovieByImdbIdAsync(movie.ImdbId);
                resultList.Add(new ShortMovieModel()
                {
                    Title = movieInfoByTitle.Title,
                    Description = movieInfoByTitle.Plot,
                    ImdbRating = movieInfoByTitle.ImdbRating,
                    Poster = movieInfoByTitle.Poster,
                    ImdbId = movieInfoByTitle.ImdbId
                });
            }

            var result = resultList.ToArray();

            return result;
        }

        public async Task<Movie> SearchMovieByImdbIdAsync(string ImdbId)
        {
            return await GetObjectOpenMovieDatabase().SearchMovieByImdbIdAsync(ImdbId);
        }



    }
}
