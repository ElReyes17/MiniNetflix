

using MiniNetflix.Core.Domain.Common;

namespace MiniNetflix.Core.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public int MovieId { get; set; }

        public string MovieName { get; set; } = string.Empty;

        public string CoverImage { get; set; } = string.Empty;

        public string MovieLink {get; set; } = string.Empty;

        public int ProducerId { get; set; }



        //Navigation Properties

        public Producer Producer { get; set; }  

        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
