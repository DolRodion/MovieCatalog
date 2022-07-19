using MovieCatalog.Application.Models;
using System.Threading.Tasks;
using MovieCatalog.Application.Interfaces;
using System;
using System.Linq;

namespace MovieCatalog.Application.Services
{
    /// <inheritdoc/>
    public class MovieService : IMovieService
    {
        private readonly IOmdbApiProvider omdbApiService;

        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="omdbApiService">Сервис работы с ImdbApi</param>
        public MovieService(IOmdbApiProvider omdbApiService)
        {
            this.omdbApiService = omdbApiService ?? throw new ArgumentNullException(nameof(omdbApiService));
        }

        
        /// <inheritdoc/>
        public async Task<ShortMovieModel[]> GetMoviesByTitleAsync(string movieTitle, int page)
        {
            if (string.IsNullOrEmpty(movieTitle)) 
            {
                throw new ArgumentNullException("Wrong movieTitle field");
            }

            if (page == default(int))
            {
                throw new ArgumentException("Wrong page field");
            }

            var data = await omdbApiService.GetMoviesByTitleAsync(movieTitle,page); 

            return data.Select(movie => new ShortMovieModel()
            {
                Title = movie.Title,
                Description = movie.Plot,
                ImdbRating = movie.ImdbRating,
                Poster = movie.Poster,
                ImdbId = movie.ImdbId
            })
            .ToArray();
        }

        /// <inheritdoc/>
        public async Task<FullMovieModel> GetFullMovieAsync(string movieId)
        {
            if (string.IsNullOrEmpty(movieId))
            {
                throw new ArgumentNullException("Wrong movieId field");
            }

            var movieInfo = await omdbApiService.GetFullMovieAsync(movieId);

            return new FullMovieModel()
            {
                Title = movieInfo.Title,
                Description = movieInfo.Plot,
                ImdbRating = movieInfo.ImdbRating,
                Poster = movieInfo.Poster,
                ImdbId = movieInfo.ImdbId,
                Actors = movieInfo.Actors,
                Country = movieInfo.Country,
                Genre = movieInfo.Genre,
                Producer = movieInfo.Writer
            };
        }

    }
}