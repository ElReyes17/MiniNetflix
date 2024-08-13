

namespace MiniNetflix.Core.Application.Dtos.Genres
{
    public class UpdateGenreDTO
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; } = string.Empty;
    }
}
