

using MiniNetflix.Core.Domain.Common;

namespace MiniNetflix.Core.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public int GenreId { get; set; }
        public string Name { get; set; } = string.Empty;


        //Navigation Properties
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}
