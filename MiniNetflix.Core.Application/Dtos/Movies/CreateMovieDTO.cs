

namespace MiniNetflix.Core.Application.Dtos.Movies
{
    public class CreateMovieDTO
    {
        public string MovieName { get; set; } = string.Empty;

        public string CoverImage { get; set; } = string.Empty;

        public int ProducerId { get; set; }

        public List<int> MovieGenres { get; set; } = new List<int>();

    }
}
