using OnlineShopping.Domain.Contract.Abstracts;
using OnlineShopping.Domain.Entities;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Domain.Repositories
{
    [ScopedService]
    public interface IProductPictureRepository : IRepository<ProductPicture, Guid>
    {
        Task<ProductPicture> GetWithProductAndCategory(Guid id);
    }
}
