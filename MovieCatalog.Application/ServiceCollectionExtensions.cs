using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieCatalog.Application.Interfaces;
using MovieCatalog.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Application
{
    /// <summary>
    /// Класс внедрения зависимости слоя бизнес логики
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавляет зависимости в общий контейнер зависимостей.
        /// </summary>
        /// <param name="services">Контейнер зависимостей.</param>
        /// <param name="configuration">Конфигурация приложения.</param>
        /// <param name="containerForTests">Будет ли использоваться контейнер для тестирования.</param>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IOmdbApiProvider, OmdbApiProvider>();

            return services;
        }
    }
}
