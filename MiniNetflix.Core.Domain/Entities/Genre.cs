

using PruebaMinimalAPI.Core.Domain.Common;

namespace PruebaMinimalAPI.Core.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; } = string.Empty;


        //Navigation Properties
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
