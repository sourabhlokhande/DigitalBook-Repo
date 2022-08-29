using ModelService.Model;

namespace ReaderApi.Services
{
    public interface IReaderService
    {
        IEnumerable<Books> GetBook();
        IEnumerable<Books> SearchBook(Books books);
        IEnumerable<Books> GetAuthorBook(string authorName);
    }
}