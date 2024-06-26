namespace Clean.Domain.Framework.Abstracts
{
    public interface IEntity<Key>
    {
        public Key Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
