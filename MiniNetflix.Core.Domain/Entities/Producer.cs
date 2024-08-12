

using PruebaMinimalAPI.Core.Domain.Common;

namespace PruebaMinimalAPI.Core.Domain.Entities
{
    public class Producer : BaseEntity
    {
        public int ProducerId { get; set; }

        public string ProducerName { get; set; } = string.Empty;


        //Navigation Properties
        public ICollection<Movie> Movies { get; set; }
    }
}
