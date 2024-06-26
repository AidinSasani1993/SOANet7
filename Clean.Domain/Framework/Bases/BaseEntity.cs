using Clean.Domain.Framework.Abstracts;

namespace Clean.Domain.Framework.Bases
{
    public class BaseEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedDate { get; private set; }
        public DateTime? ActiveDate { get; private set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }

        public void Modify()
        {
            ModifiedDate = DateTime.Now;
        }

        public void Remove()
        {
            IsDeleted = true;
            DeletedDate = DateTime.Now;
        }

        public void Active()
        {
            IsDeleted = false;
            ActiveDate = DateTime.Now;
        }
    }
}
