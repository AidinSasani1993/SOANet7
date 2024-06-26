using MehrSepand.Framework.Domain.BaseEntities;

namespace Clean.Domain.Entities
{
    public class Person : BaseEntity<long>
    {
        public string Name { get; protected set; }
        //public ICollection<CompanyEntity> CompanyEntities { get; set; }
        public bool IsDeleted { get; protected set; }
        public DateTime? DeletedDate { get; protected set; }
        public DateTime? ActiveDate { get; protected set; }


        public void Modify(string name)
        {
            Name = name;
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
