using ModelService.Model;

namespace AuthService.Services
{
    public interface ITokenService
    {
        Author ValidateUser(Author author);
        string BuildToken(string key, string issuer, IEnumerable<string> audience, Author author);
    }
}