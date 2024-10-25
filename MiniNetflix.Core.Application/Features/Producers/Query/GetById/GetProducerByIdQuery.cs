

using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Producers;

namespace MiniNetflix.Core.Application.Features.Producers.Query.GetById
{
    public record GetProducerByIdQuery(int Id) : IRequest<Result<ProducerDto>> { }
   
}
