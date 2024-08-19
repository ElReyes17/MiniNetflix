

using MediatR;
using MiniNetflix.Core.Application.Common;

namespace MiniNetflix.Core.Application.Features.Movies.Command.Delete
{
    public record DeleteMovieCommand(int Id) : IRequest<Result<Unit>> { }
   
}
