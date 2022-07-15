using Microsoft.AspNetCore.Mvc;
using MovieCatalog.Application.Interfaces;
using MovieCatalog.Application.Models;
using System.Threading.Tasks;

namespace MovieСatalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        /// <summary>
        /// Получить фильмы для стартовой страницы
        /// </summary>
        [HttpGet]
        [Route("GetMovies")]
        public async Task<ActionResult<ShortMovieModel[]>> GetMoviesAsync()
        {
            var result = await movieService.GetMoviesAsync();

            return Ok(result);
        }

        /// <summary>
        /// Получить фильмы по его названию
        /// </summary>
        [HttpGet]
        [Route("GetMoviesByTitle")]
        public async Task<ActionResult<ShortMovieModel[]>> GetMoviesByTitleAsync(string movieTitle)
        {
            var result = await movieService.GetMoviesByTitleAsync(movieTitle);

            return Ok(result);
        }

    }
}
