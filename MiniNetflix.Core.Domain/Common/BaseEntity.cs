

namespace MiniNetflix.Core.Domain.Common
{
    public class BaseEntity
    {
        public string? CreatedBy { get; set; } 
        public string? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set;}
        public bool IsDeleted { get; set; }

    }
}
