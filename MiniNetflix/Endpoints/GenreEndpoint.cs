using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using MiniNetflix.Core.Application.Dtos.Genres;
using MiniNetflix.Core.Application.Features.Genres.Command.Create;
using MiniNetflix.Core.Application.Features.Genres.Query.GetAll;
using MiniNetflix.Core.Application.Features.Genres.Query.GetById;

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
                     return opt;

                 });

            group.MapGet("/{id:int}", GetById)
                 .WithOpenApi(opt =>
                 {
                     opt.Summary = "Obtener un Género por Id";
                     opt.Description = "Con este endpoint podemos obtener un géneros por su Id";
                     return opt;

                 });

            group.MapPost("/", Create)
                 .WithOpenApi(opt =>
                 {
                     opt.Summary = "Crear Géneros";
                     opt.Description = "Con este endpoint podemos crear  los géneros";
                     return opt;
                 });

            return group;

        }

        static async Task<Ok<List<GenreDTO>>> Get(ISender mediator)
        {
            var genre =  await mediator.Send(new GetAllGenreQuery());

            return TypedResults.Ok(genre.Value);

        }

        static async Task<Ok<GenreDTO>> GetById(ISender mediator, int id)
        {
            var genre = await mediator.Send(new GetGenreByIdQuery(id));

            return TypedResults.Ok(genre.Value);
        }

        static async Task<Results<Created, NotFound>> Create(ISender mediator, CreateGenreCommand command)
        {
            await mediator.Send(command);

            return TypedResults.Created();
        }


    }
}
