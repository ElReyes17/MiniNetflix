
using MediatR;
using MiniNetflix.Core.Application.Common;


namespace MiniNetflix.Core.Application.Features.Genres.Command.Update
{
    public record UpdateGenreCommand : IRequest<Result<Unit>> 
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; } = string.Empty;
    }
    
    
}
