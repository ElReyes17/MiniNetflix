

using MiniNetflix.Core.Domain.Common;

namespace MiniNetflix.Core.Domain.Entities
{
    #nullable disable
    public class Movie : BaseEntity
    {
        public int MovieId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CoverImage { get; set; } = string.Empty;
        public string Link {get; set; } = string.Empty;


        //Navigation Properties
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }  

        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}
