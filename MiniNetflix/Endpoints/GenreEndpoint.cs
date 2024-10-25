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

        static async Task<Results<Ok<Result<List<GenreDto>>>, BadRequest<string>>> Get(ISender mediator)
        {
            var response =  await mediator.Send(new GetAllGenreQuery());
            if (!response.IsSuccess) return TypedResults.BadRequest(response.ErrorMessage);
            return TypedResults.Ok(response);

        }

        static async Task<Results<Ok<Result<GenreDto>>, BadRequest<string>>> GetById(ISender mediator, int id)
        {
            var response = await mediator.Send(new GetGenreByIdQuery(id));
            if (!response.IsSuccess) return TypedResults.BadRequest(response.ErrorMessage);
            return TypedResults.Ok(response);
        }

        static async Task<Results<Created, BadRequest<string>>> Create(ISender mediator, CreateGenreCommand command)
        {
            var request = await mediator.Send(command);
            if (!request.IsSuccess) return TypedResults.BadRequest(request.ErrorMessage);
            return TypedResults.Created();
        }

        static async Task<Results<NoContent, BadRequest<string>>> Update(ISender mediator, UpdateGenreCommand command)
        {
            var request = await mediator.Send(command);
            if (!request.IsSuccess)return TypedResults.BadRequest(request.ErrorMessage);
            return TypedResults.NoContent();
        }

        static async Task<Results<NoContent, BadRequest<string>>> Delete(ISender mediator, int id)
        {
            var request = await mediator.Send(new DeleteGenreCommand(id));
            if (!request.IsSuccess) return TypedResults.BadRequest(request.ErrorMessage);
            return TypedResults.NoContent();
        }


    }
}
