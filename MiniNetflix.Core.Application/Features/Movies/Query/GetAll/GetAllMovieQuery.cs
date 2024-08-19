using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Movies;

namespace MiniNetflix.Core.Application.Features.Movies.Query.GetAll
{
    public record GetAllMovieQuery : IRequest<Result<List<MovieDTO>>> { }
   
    
}
