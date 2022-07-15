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
    public interface IImdbApiService
    {
        OpenMovieDatabaseService GetObjectOpenMovieDatabase();
        Task<ShortMovieModel[]> GetMoviesByTitle(string movieTitle);
        Task<Movie> SearchMovieByImdbIdAsync(string ImdbId);

    }
}
