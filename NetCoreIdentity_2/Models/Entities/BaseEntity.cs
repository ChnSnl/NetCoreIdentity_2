using NetCoreIdentity_2.Models.Enums;
using NetCoreIdentity_2.Models.Interfaces;

namespace NetCoreIdentity_2.Models.Entities
{
    public class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}
