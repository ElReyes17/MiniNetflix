

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaMinimalAPI.Core.Application.Interfaces.Repositories;
using PruebaMinimalAPI.Infrastructure.Persistence.Context;
using PruebaMinimalAPI.Infrastructure.Persistence.Repositories;

namespace PruebaMinimalAPI.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //Configuracion del Contexto y Conexión a Base de Datos
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString(""),
                                                        m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));


            //Configurando Dependencias 

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();

        }

    }
}
