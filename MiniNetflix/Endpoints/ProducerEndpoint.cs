using Azure;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Genres;
using MiniNetflix.Core.Application.Dtos.Producers;
using MiniNetflix.Core.Application.Features.Producers.Command.Create;
using MiniNetflix.Core.Application.Features.Producers.Command.Delete;
using MiniNetflix.Core.Application.Features.Producers.Command.Update;
using MiniNetflix.Core.Application.Features.Producers.Query.GetAll;
using MiniNetflix.Core.Application.Features.Producers.Query.GetById;

namespace MiniNetflix.Endpoints
{
    public static class ProducerEndpoint
    {
        public static RouteGroupBuilder MapProducer(this RouteGroupBuilder group)
        {
            group.MapGet("/", Get)
                 .WithOpenApi(opt =>
                 {
                     opt.Summary = "Obtener Productoras";
                     opt.Description = "Con este endpoint podemos obtener todas las Productoras";
                     return opt;

                 });

            group.MapGet("/{id:int}", GetById)
                 .WithOpenApi(opt =>
                 {
                     opt.Summary = "Obtener una Productoras por Id";
                     opt.Description = "Con este endpoint podemos obtener una Productoras por su Id";
                     return opt;

                 });

            group.MapPost("/", Create)
                 .WithOpenApi(opt =>
                 {
                     opt.Summary = "Crear Productora";
                     opt.Description = "Con este endpoint podemos crear  las Productoras";
                     return opt;
                 });

            group.MapPut("/", Update)
                .WithOpenApi(opt =>
                {
                    opt.Summary = "Actualizar Productora";
                    opt.Description = "Con este endpoint podemos actualizar las Productoras";
                    return opt;
                });

            group.MapDelete("/", Delete)
                .WithOpenApi(opt =>
                {
                    opt.Summary = "Eliminar Productora";
                    opt.Description = "Con este endpoint podemos eliminar una Productora";
                    return opt;

                });

            return group;

        }

        static async Task<Results<Ok<Result<List<ProducerDTO>>>, BadRequest<string>>> Get(ISender mediator)
        {
            var response = await mediator.Send(new GetAllProducerQuery());

            if (!response.IsSuccess)
            {
                return TypedResults.BadRequest(response.ErrorMessage);
            }

            return TypedResults.Ok(response);

        }
         
        static async Task<Results<Ok<Result<ProducerDTO>>, BadRequest<string>>> GetById(ISender mediator, int id)
        {
            var response = await mediator.Send(new GetProducerByIdQuery(id));


            if (!response.IsSuccess)
            {
                return TypedResults.BadRequest(response.ErrorMessage);
            }


            return TypedResults.Ok(response);
        }

        static async Task<Results<Created, BadRequest<string>>> Create(ISender mediator, CreateProducerCommand command)
        {
           var request = await mediator.Send(command);

            if (!request.IsSuccess)
            {
                return TypedResults.BadRequest(request.ErrorMessage);
            }

            return TypedResults.Created();
        }

        static async Task<Results<NoContent, BadRequest<string>>> Update(ISender mediator, UpdateProducerCommand command)
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
            var request = await mediator.Send(new DeleteProducerCommand(id));

            if (!request.IsSuccess)
            {
                return TypedResults.BadRequest(request.ErrorMessage);
            }

            return TypedResults.NoContent();
        }


    }
}

