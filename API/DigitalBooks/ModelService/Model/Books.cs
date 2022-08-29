using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelService.Model
{
    public class Books
    {
        [Key]
        public long? BookId { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public decimal? Price { get; set; }
        public string? Publisher { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        public bool? Active { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public long AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author? Author { get; set; }
    }
}
