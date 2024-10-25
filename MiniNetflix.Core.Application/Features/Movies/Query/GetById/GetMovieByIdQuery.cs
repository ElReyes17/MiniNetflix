using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Movies;


namespace MiniNetflix.Core.Application.Features.Movies.Query.GetById
{
    public record GetMovieByIdQuery(int Id) : IRequest<Result<MovieDto>> { }
}
