

using MediatR;
using MiniNetflix.Core.Application.Common;

namespace MiniNetflix.Core.Application.Features.Genres.Command.Delete
{
    public record DeleteGenreCommand(int Id) : IRequest<Result<Unit>> { }
    
}
