using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Application.Models
{
    /// <summary>
    /// Полное описание фильма
    /// </summary>
    public class FullMovieModel
    {
        /// <summary>
        /// Id фильма
        /// </summary>
        public string ImdbId { get; set; }

        /// <summary>
        /// Название фильма
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание фильма
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Постер фильма
        /// </summary>
        public string Poster { get; set; }

        /// <summary>
        /// Рейтинг фильма
        /// </summary>
        public string ImdbRating { get; set; }

        /// <summary>
        /// Актеры(в главных ролях)
        /// </summary>
        public string Actors { get; set; }

        /// <summary>
        /// Страна съемки
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Жанр/ы фильма
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Продюсер
        /// </summary>
        public string Producer { get; set; }




    }
}
