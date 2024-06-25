using Microsoft.AspNetCore.Http;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Application.Abstracts
{
    [ScopedService]
    public interface IFileUploader
    {
        string Upload(IFormFile file, string path);
    }
}
