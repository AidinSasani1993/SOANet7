namespace OnlineShopping.Application.Contract.Abstracts.Dtos
{
    public interface IDto<TKey>
    {
        public TKey Id { get; set; }
    }
}
