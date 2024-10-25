using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Movies;

namespace MiniNetflix.Core.Application.Features.Movies.Command.Create
{
    public record CreateMovieCommand : IRequest<Result<Unit>> 
    {
        public string MovieName { get; set; } = string.Empty;
        public string CoverImage { get; set; } = string.Empty;
        public string MovieLink { get; set; } = string.Empty;
        public int ProducerId { get; set; }
        public List<int> MovieGenres { get; set; } = new List<int>();

    }
    
}
