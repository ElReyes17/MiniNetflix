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

        static async Task<Results<Ok<Result<List<MovieDTO>>>, BadRequest<string>>> Get(ISender mediator)
        {
            var response = await mediator.Send(new GetAllMovieQuery());

            if (!response.IsSuccess)
            {
                return TypedResults.BadRequest(response.ErrorMessage);
            }

            return TypedResults.Ok(response);

        }

        static async Task<Results<Ok<Result<MovieDTO>>, BadRequest<string>>> GetById(ISender mediator, int id)
        {            
            var response = await mediator.Send(new GetMovieByIdQuery(id));

            if(!response.IsSuccess)
            {
                return TypedResults.BadRequest(response.ErrorMessage);
            }

            return TypedResults.Ok(response);
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

        static async Task<Results<NoContent, BadRequest<string>>> Update(ISender mediator, UpdateMovieCommand command)
        {
            var request = await mediator.Send(command);

            if (!request.IsSuccess)
            {
                return TypedResults.BadRequest(request.ErrorMessage);
            }

            return TypedResults.NoContent();
        }

        static async Task<Results<NoContent, BadRequest<string>>> Delete(ISender mediator, int id)
        {
            var request = await mediator.Send(new DeleteMovieCommand(id));

            if (!request.IsSuccess)
            {
                return TypedResults.BadRequest(request.ErrorMessage);
            }

            return TypedResults.NoContent();
        }


    }
}

