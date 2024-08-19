

using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Movies;

namespace MiniNetflix.Core.Application.Features.Movies.Command.Update
{
    public record UpdateMovieCommand(UpdateMovieDTO UpdateMovieDTO) : IRequest<Result<Unit>> { }
   
}
