

using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Producers;

namespace MiniNetflix.Core.Application.Features.Producers.Command.Update
{
    public record UpdateProducerCommand : IRequest<Result<Unit>> 
    {
        public int ProducerId { get; set; }
        public string ProducerName { get; set; } = string.Empty;

    }
    
}
