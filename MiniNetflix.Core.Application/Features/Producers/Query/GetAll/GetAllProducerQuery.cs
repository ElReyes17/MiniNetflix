using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Producers;

namespace MiniNetflix.Core.Application.Features.Producers.Query.GetAll
{
    public class GetAllProducerQuery : IRequest<Result<List<ProducerDto>>> { }
    
}
