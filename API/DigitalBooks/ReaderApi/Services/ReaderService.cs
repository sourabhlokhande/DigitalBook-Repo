using ModelService.Data;
using ModelService.Model;

namespace ReaderApi.Services
{
    public class ReaderService : IReaderService
    {
        private readonly ApplicationDbContext _dbContext;

        public ReaderService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Books> GetAuthorBook(string authorName)
        {
            try
            {
                var authorObj = _dbContext.AuthorTbl.First(a => a.AuthorName == authorName);
                return _dbContext.BookTbl.Where(b => b.AuthorId == authorObj.AuthorId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Books> GetBook()
        {
            try
            {
                return _dbContext.BookTbl.ToList().Where(b => b.Active == true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public IEnumerable<Books> SearchBook(Books filter)
        {
            try
            {
                return _dbContext.BookTbl.Where(b => b.Title.Contains(filter.Title) || b.Publisher.Contains(filter.Publisher) || b.Category.Contains(filter.Category) || b.Price.Equals(filter.Price)).ToList().Where(b=> b.Active == true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
