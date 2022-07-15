using MovieCatalog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MovieCatalog.Application.Interfaces;
using System.Net.Http;
using MovieCollection.OpenMovieDatabase;
using MovieCollection.OpenMovieDatabase.Enums;

namespace MovieCatalog.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IConfiguration configuration;
        private readonly HttpClient httpClient = new HttpClient();

        public MovieService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Получение фильмов для стартовой страницы
        /// </summary>
        // <returns></returns>
        public async Task<ShortMovieModel[]> GetMoviesAsync()
        {
            var options = new OpenMovieDatabaseOptions(configuration["OMDbApiKey"]);
            var service = new OpenMovieDatabaseService(httpClient, options);

            var words = new string[] { "avengers", "water", "cold", "thirst", "war", "world", "save", "bounce" , "one", "explosion"};

            Random x = new Random();

            var moviesByWord = await service.SearchMoviesAsync(words[x.Next(0, 9)], "", SearchType.Movie);

            if (!moviesByWord.IsSuccess)
            {
                 throw new Exception("Ошибка получения фильмов");
            }

            var resultList = new List<ShortMovieModel>();

            foreach (var movie in moviesByWord.Items)
            {
                var movieInfoByTitle = await service.SearchMovieByImdbIdAsync(movie.ImdbId);
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

        public async Task<ShortMovieModel[]> GetMoviesByTitleAsync(string movieTitle)
        {


            return null;
        }



    }
}