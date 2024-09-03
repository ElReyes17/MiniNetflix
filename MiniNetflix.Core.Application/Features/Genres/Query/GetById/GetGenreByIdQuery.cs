using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Genres;

namespace MiniNetflix.Core.Application.Features.Genres.Query.GetById
{
    public record GetGenreByIdQuery(int Id) : IRequest<Result<GenreDTO>> { }
  
}
