using Microsoft.EntityFrameworkCore;
using ModelService.Model;

namespace ModelService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Author> AuthorTbl { get; set; }
        public DbSet<Books> BookTbl { get; set; }
        public DbSet<Payment> PaymentTbl { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Author>()
        //      .HasIndex(author => author.AuthorName)
        //        .IsUnique();
        //}
    }
}
