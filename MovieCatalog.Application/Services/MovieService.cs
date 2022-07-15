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
        private readonly IImdbApiService imdbApiService;

        public MovieService(IImdbApiService imdbApiService)
        {
            this.imdbApiService = imdbApiService;
        }


        /// <summary>
        /// Получение фильмов для стартовой страницы
        /// </summary>
        // <returns></returns>
        public async Task<ShortMovieModel[]> GetMoviesAsync()
        {
            var words = new string[] { "avengers", "water", "cold", "thirst", "war", "world", "save", "bounce" , "one", "explosion"};

            Random x = new Random();

            return await imdbApiService.GetMoviesByTitle(words[x.Next(0, 9)]); ;
        }


        public async Task<ShortMovieModel[]> GetMoviesByTitleAsync(string movieTitle)
        {

            return await imdbApiService.GetMoviesByTitle(movieTitle); 
        }



    }
}