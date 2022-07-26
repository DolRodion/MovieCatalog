﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Application.Models
{
    /// <summary>
    /// Краткое описание фильма
    /// </summary>
    public class ShortMovieModel
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

    }
}
