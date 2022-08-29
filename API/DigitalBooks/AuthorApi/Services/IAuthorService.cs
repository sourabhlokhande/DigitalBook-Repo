using ModelService.Model;

namespace AuthorApi.Services
{
    public interface IAuthorService
    {
        string AddAuthor(Author author);
    }
}