using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using MiniNetflix.Core.Application.Common;
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

        static async Task<Ok<Result<List<ProducerDTO>>>> Get(ISender mediator)
        {
            var producer = await mediator.Send(new GetAllProducerQuery());

            return TypedResults.Ok(producer);

        }
         
        static async Task<Ok<Result<ProducerDTO>>> GetById(ISender mediator, int id)
        {
            var producer = await mediator.Send(new GetProducerByIdQuery(id));

            return TypedResults.Ok(producer);
        }

        static async Task<Results<Created, NotFound>> Create(ISender mediator, CreateProducerCommand command)
        {
            await mediator.Send(command);

            return TypedResults.Created();
        }

        static async Task<Results<NoContent, NotFound>> Update(ISender mediator, UpdateProducerCommand command)
        {
            await mediator.Send(command);

            return TypedResults.NoContent();
        }

        static async Task<Results<NoContent, NotFound>> Delete(ISender mediator, int id)
        {
            await mediator.Send(new DeleteProducerCommand(id));

            return TypedResults.NoContent();
        }


    }
}

