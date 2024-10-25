

using MiniNetflix.Core.Domain.Common;

namespace MiniNetflix.Core.Domain.Entities
{
    public class Producer : BaseEntity
    {
        public int ProducerId { get; set; }
        public string Name { get; set; } = string.Empty;


        //Navigation Properties
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
