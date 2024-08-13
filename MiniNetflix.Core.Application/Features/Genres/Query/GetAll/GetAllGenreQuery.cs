using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Genres;

namespace MiniNetflix.Core.Application.Features.Genres.Query.GetAll
{
    public record GetAllGenreQuery : IRequest<Result<List<GenreDTO>>> { }
    
}
