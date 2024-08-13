

using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Genres;

namespace MiniNetflix.Core.Application.Features.Genres.Command.Update
{
    public record UpdateGenreCommand(UpdateGenreDTO updateGenreDTO) : IRequest<Result<Unit>> { }
    
    
}
