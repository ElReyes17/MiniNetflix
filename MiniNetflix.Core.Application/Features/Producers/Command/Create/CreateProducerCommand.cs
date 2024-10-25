

using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Producers;

namespace MiniNetflix.Core.Application.Features.Producers.Command.Create
{
    public record CreateProducerCommand : IRequest<Result<Unit>> 
    {
        public string ProducerName { get; set; } = string.Empty;
    }
   
}
