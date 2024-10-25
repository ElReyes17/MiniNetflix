using MediatR;
using MiniNetflix.Core.Application.Common;


namespace MiniNetflix.Core.Application.Features.Movies.Command.Update
{
    public record UpdateMovieCommand : IRequest<Result<Unit>> 
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; } = string.Empty;
        public string CoverImage { get; set; } = string.Empty;
        public string MovieLink { get; set; } = string.Empty;
        public int ProducerId { get; set; }
        public List<int> MovieGenres { get; set; } = new List<int>();
    }
   
}
