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
    }
}
