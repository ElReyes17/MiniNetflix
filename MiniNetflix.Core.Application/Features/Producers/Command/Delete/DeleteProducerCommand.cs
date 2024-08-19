

using MediatR;
using MiniNetflix.Core.Application.Common;

namespace MiniNetflix.Core.Application.Features.Producers.Command.Delete
{
    public record DeleteProducerCommand(int Id) : IRequest<Result<Unit>> { }
   
}
