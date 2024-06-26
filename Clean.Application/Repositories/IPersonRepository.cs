using Clean.Domain.Entities;
using MehrSepand.Framework.Repository;

namespace Clean.Application.Repositories
{
    public interface IPersonRepository : IGenericRepository<Person, long>
    {
    }
}
