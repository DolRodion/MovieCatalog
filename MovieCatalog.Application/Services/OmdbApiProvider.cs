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
    /// <inheritdoc/>
    public class OmdbApiProvider : IOmdbApiProvider
    {
        private readonly OpenMovieDatabaseService _openMovieDatabaseService;

        public OmdbApiProvider(IConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var apiKey = configuration["OMDbApiKey"];

            if (apiKey is null)
            {
                throw new Exception("apiKey not found");
            }

            _openMovieDatabaseService = new OpenMovieDatabaseService(new HttpClient(), new OpenMovieDatabaseOptions(apiKey));
        }

        /// <inheritdoc/>
        public async Task<Movie[]> GetMoviesByTitleAsync(string movieTitle, int page)
        {
            try
            {
                var moviesByMovieTitle = await _openMovieDatabaseService.SearchMoviesAsync(movieTitle, "", SearchType.Movie, page);

                if (!moviesByMovieTitle.IsSuccess)
                {
                    throw new Exception("Error receiving movies");
                }

                //Достаём дополнительные данные по каждому фильму, так как
                //в исходных данных нет всей информации, необходимой для вывода по ТЗ
                var resultList = new List<Movie>(moviesByMovieTitle.Items.Count());

                foreach (var movie in moviesByMovieTitle.Items)
                {
                    var movieInfo = await SearchMovieByIdAsync(movie.ImdbId);

                    resultList.Add(movieInfo);
                }

                return resultList.ToArray();
            }

            catch 
            {
                throw new Exception("Error receiving movies");
            }
            
        }

        /// <inheritdoc/>
        public Task<Movie> GetFullMovieAsync(string movieId)
        {

            return SearchMovieByIdAsync(movieId);
        }

        /// <summary>
        /// Получаем полную информацию о фильме по его id
        /// </summary>
        /// <param name="ImdbId">id фильма</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<Movie> SearchMovieByIdAsync(string ImdbId)
        {
            try
            {
                return await _openMovieDatabaseService.SearchMovieByImdbIdAsync(ImdbId);
            }
            catch
            {
                throw new Exception("Error receiving movie");
            }
        }
    }
}
