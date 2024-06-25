using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Application.Abstracts
{
    [ScopedService]
    public interface IPasswordHasher
    {
        string Hash(string password);
        (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
    }
}
