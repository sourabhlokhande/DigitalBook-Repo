using ModelService.Data;
using ModelService.Model;

namespace AuthorApi.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string AddAuthor(Author author)
        {
            try
            {
                _dbContext.AuthorTbl.Add(author);
                _dbContext.SaveChanges();
                return $"{author.AuthorName} Added Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
