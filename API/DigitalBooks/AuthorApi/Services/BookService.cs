using ModelService.Data;
using ModelService.Model;

namespace AuthorApi.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _dbContext;

        public BookService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string AddBook(Books books)
        {
            try
            {
                _dbContext.BookTbl.Add(books);
                _dbContext.SaveChanges();
                return $"{books.Title} Added Successfully";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public string UpdateBook(Books books)
        {
            try
            {
                var book = _dbContext.BookTbl.Find(books.BookId);
                book.Title = books.Title;
                book.Category = books.Category;
                book.Price = books.Price;
                book.Publisher = books.Publisher;
                book.Active = books.Active;
                book.Content = books.Content;
                book.ModifiedDate = books.ModifiedDate;
                _dbContext.BookTbl.Update(book);
                _dbContext.SaveChanges();
                return $"{books.Title} Book Updated Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
