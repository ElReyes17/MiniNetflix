

using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Producers;

namespace MiniNetflix.Core.Application.Features.Producers.Command.Update
{
    public record UpdateProducerCommand(UpdateProducerDTO UpdateProducerDTO) : IRequest<Result<Unit>> { }
    
}
