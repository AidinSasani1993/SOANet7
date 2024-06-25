namespace OnlineShopping.Domain.Contract.Abstracts
{
    public interface IGetRepository<TEntity, T_Key> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(T_Key id);
        Task<List<TEntity>> GetAllAsync();
    }
}
