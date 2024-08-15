using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using MiniNetflix.Core.Application.Dtos.Genres;
using MiniNetflix.Core.Application.Features.Genres.Query.GetAll;

namespace MiniNetflix.Endpoints
{
    public static class GenreEndpoint
    {
        public static RouteGroupBuilder MapGenre(this RouteGroupBuilder group)
        {
            group.MapGet("/", Get)
                 .WithOpenApi(opt =>
                 {
                     opt.Summary = "Obtener Géneros";
                     opt.Description = "Con este endpoint podemos obtener todos los géneros";
                     opt.Parameters[0].Description = "Número de página";
                     opt.Parameters[1].Description = "Números de registro por página";
                     return opt;

                 });

            return group;

        }

        static async Task<Ok<List<GenreDTO>>> Get(ISender mediator)
        {
            var genre =  await mediator.Send(new GetAllGenreQuery());

            return TypedResults.Ok(genre.Value);

        }


    }
}
