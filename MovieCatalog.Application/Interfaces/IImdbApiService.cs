using MovieCatalog.Application.Models;
using MovieCollection.OpenMovieDatabase;
using MovieCollection.OpenMovieDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Application.Interfaces
{
    /// <summary>
    /// Провайдер работы с OmdbApi
    /// </summary>
    public interface IOmdbApiProvider
    {
        /// <summary>
        /// Получает фильмы по названию
        /// </summary>
        /// <param name="movieTitle">Название</param>
        /// <param name="page">Страница</param>
        Task<Movie[]> GetMoviesByTitleAsync(string movieTitle, int page);

        /// <summary>
        /// Получает подробную информацию о фильме по его идентификатору
        /// </summary>
        /// <param name="movieId">Идентификатор фильма</param>
        Task<Movie> GetFullMovieAsync(string movieId);

    }
}
