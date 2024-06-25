namespace OnlineShopping.Domain.Framework.Abstracts
{
    public abstract class Entity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public Entity()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
