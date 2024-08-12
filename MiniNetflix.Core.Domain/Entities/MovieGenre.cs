

using MiniNetflix.Core.Domain.Common;

namespace MiniNetflix.Core.Domain.Entities
{
    public class MovieGenre : BaseEntity
    {
        public int MovieId { get; set; }

        public int GenreId { get; set; }


        //Navigation Properties
        public Movie Movie { get; set; }

        public Genre Genre { get; set; }
    }
}
