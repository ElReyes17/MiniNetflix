using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Genres;
using MiniNetflix.Core.Application.Features.Genres.Command.Create;
using MiniNetflix.Core.Application.Features.Genres.Command.Delete;
using MiniNetflix.Core.Application.Features.Genres.Command.Update;
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

            group.MapPut("/", Update)
                .WithOpenApi(opt =>
                {
                    opt.Summary = "Actualizar Géneros";
                    opt.Description = "Con este endpoint podemos actualizar los géneros";
                    return opt;
                });

            group.MapDelete("/", Delete)
                .WithOpenApi(opt =>
                {
                    opt.Summary = "Eliminar Géneros";
                    opt.Description = "Con este endpoint podemos eliminar un género";
                    return opt;

                });

            return group;

        }

        static async Task<Ok<Result<List<GenreDTO>>>> Get(ISender mediator)
        {
            var genre =  await mediator.Send(new GetAllGenreQuery());

            return TypedResults.Ok(genre);

        }

        static async Task<Ok<Result<GenreDTO>>> GetById(ISender mediator, int id)
        {
            var genre = await mediator.Send(new GetGenreByIdQuery(id));

            return TypedResults.Ok(genre);
        }

        static async Task<Results<Created, NotFound>> Create(ISender mediator, CreateGenreCommand command)
        {
          var response =  await mediator.Send(command);
            
            return TypedResults.Created();
        }

        static async Task<Results<NoContent, NotFound>> Update(ISender mediator, UpdateGenreCommand command)
        {
            await mediator.Send(command);

            return TypedResults.NoContent();
        }

        static async Task<Results<NoContent, NotFound>> Delete(ISender mediator, int id)
        {
            await mediator.Send(new DeleteGenreCommand(id));

            return TypedResults.NoContent();
        }


    }
}
