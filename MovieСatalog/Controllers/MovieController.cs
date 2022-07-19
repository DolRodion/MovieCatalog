using Microsoft.AspNetCore.Mvc;
using MovieCatalog.Application.Interfaces;
using MovieCatalog.Application.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MovieСatalog.Controllers
{
    /// <summary>
    /// Контроллер фильмов
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;

        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="movieService">Сервис фильмов</param>
        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService ?? throw new System.ArgumentNullException(nameof(movieService));
        }

        /// <summary>
        /// Получает фильмы по его названию
        /// </summary>
        /// <param name="movieTitle">Заголовок фильма</param>
        /// <param name="page">Страница</param>
        [HttpGet]
        [Route("GetMoviesByTitle")]
        public async Task<ActionResult<ShortMovieModel[]>> GetMoviesByTitleAsync([Required] string movieTitle, [Required] int page)
        {
            var result = await movieService.GetMoviesByTitleAsync(movieTitle, page);

            return Ok(result);
        }

        /// <summary>
        /// Получает полную информацию о фильме по id
        /// </summary>
        /// <param name="movieId">Идентфикатор фильма</param>
        [HttpGet]
        [Route("GetFullMovie")]
        public async Task<ActionResult<FullMovieModel>> GetFullMovieAsync([Required] string movieId)
        {
            var result = await movieService.GetFullMovieAsync(movieId);

            return Ok(result);
        }
    }
}
