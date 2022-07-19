using MovieCatalog.Application.Models;
using System.Threading.Tasks;

namespace MovieCatalog.Application.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с фильмами
    /// </summary>
    public interface IMovieService
    {
        /// <summary>
        /// Получает фильмы по его названию
        /// </summary>
        /// <param name="movieTitle">Заголовок фильма</param>
        /// <param name="page">Страница</param>
        Task<ShortMovieModel[]> GetMoviesByTitleAsync(string movieTitle, int page);

        /// <summary>
        /// Получает полную информацию о фильме по id
        /// </summary>
        /// <param name="movieId">Идентфикатор фильма</param>
        Task<FullMovieModel> GetFullMovieAsync(string movieId);

    }
}
