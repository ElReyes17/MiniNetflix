using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Genres;

namespace MiniNetflix.Core.Application.Features.Genres.Command.Create
{
    public record CreateGenreCommand(CreateGenreDTO createGenreDTO) : IRequest<Result<Unit>> { }
 
}