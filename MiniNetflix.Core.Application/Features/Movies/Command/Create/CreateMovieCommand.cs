using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Movies;

namespace MiniNetflix.Core.Application.Features.Movies.Command.Create
{
    public record CreateMovieCommand(CreateMovieDTO createMovieDTO) : IRequest<Result<Unit>> { }
    
}
