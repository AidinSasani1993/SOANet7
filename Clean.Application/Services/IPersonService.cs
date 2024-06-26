using Clean.Application.Models.Dtos;

namespace Clean.Application.Services
{
    public interface IPersonService
    {
        Task CreateAsync(AddPerson input);
    }
}
