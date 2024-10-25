using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Application.Interfaces.UnitOfWork;
using MiniNetflix.Infrastructure.Persistence.Context;
using MiniNetflix.Infrastructure.Persistence.Repositories;

namespace MiniNetflix.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //Configuracion del Contexto y Conexión a Base de Datos
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
                                                      configuration.GetConnectionString("DefaultConnection"),
                                                      m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));


            //Configurando Dependencias 

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IProducerRepository, ProducerRepository>();
            services.AddTransient<IMovieGenreRepository, MovieGenreRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>(); 

        }

    }
}
