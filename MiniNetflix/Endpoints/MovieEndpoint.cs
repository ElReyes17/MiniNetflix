using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Movies;
using MiniNetflix.Core.Application.Features.Movies.Command.Create;
using MiniNetflix.Core.Application.Features.Movies.Command.Delete;
using MiniNetflix.Core.Application.Features.Movies.Command.Update;
using MiniNetflix.Core.Application.Features.Movies.Query.GetAll;
using MiniNetflix.Core.Application.Features.Movies.Query.GetById;

namespace MiniNetflix.Endpoints
{
    public static class MovieEndpoint
    {
        public static RouteGroupBuilder MapMovie(this RouteGroupBuilder group)
        {
            group.MapGet("/", Get)
                 .WithOpenApi(opt =>
                 {
                     opt.Summary = "Obtener Películas";
                     opt.Description = "Con este endpoint podemos obtener todas las Películas";
                     return opt;

                 });

            group.MapGet("/{id:int}", GetById)
                 .WithOpenApi(opt =>
                 {
                     opt.Summary = "Obtener una Película por Id";
                     opt.Description = "Con este endpoint podemos obtener una Película por su Id";
                     return opt;

                 });

            group.MapPost("/", Create)
                 .WithOpenApi(opt =>
                 {
                     opt.Summary = "Crear Película";
                     opt.Description = "Con este endpoint podemos crear  lss Películas";
                     return opt;
                 });

            group.MapPut("/", Update)
                .WithOpenApi(opt =>
                {
                    opt.Summary = "Actualizar Películas";
                    opt.Description = "Con este endpoint podemos actualizar las Películas";
                    return opt;
                });

            group.MapDelete("/", Delete)
                .WithOpenApi(opt =>
                {
                    opt.Summary = "Eliminar Películas";
                    opt.Description = "Con este endpoint podemos eliminar una Película";
                    return opt;

                });

            return group;

        }

        static async Task<Ok<Result<List<MovieDTO>>>> Get(ISender mediator)
        {
            var movie = await mediator.Send(new GetAllMovieQuery());

            return TypedResults.Ok(movie);

        }

        static async Task<Ok<Result<MovieDTO>>> GetById(ISender mediator, int id)
        {
            var movie = await mediator.Send(new GetMovieByIdQuery(id));

            return TypedResults.Ok(movie);
        }

        static async Task<Results<Created, BadRequest<string>>> Create(ISender mediator, CreateMovieCommand command)
        {
            var request = await mediator.Send(command);

            if (!request.IsSuccess)
            {
                return TypedResults.BadRequest(request.ErrorMessage);    
            }         

            return TypedResults.Created();
        }

        static async Task<Results<NoContent, NotFound>> Update(ISender mediator, UpdateMovieCommand command)
        {
            await mediator.Send(command);

            return TypedResults.NoContent();
        }

        static async Task<Results<NoContent, NotFound>> Delete(ISender mediator, int id)
        {
            await mediator.Send(new DeleteMovieCommand(id));

            return TypedResults.NoContent();
        }


    }
}

