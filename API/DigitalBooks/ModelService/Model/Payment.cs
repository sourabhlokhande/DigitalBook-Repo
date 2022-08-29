using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelService.Model
{
    public class Payment
    {
        [Key]
        public long PaymentId { get; set; }
        public string? Email { get; set; }
        public string? CreatedDate { get; set; }
        public string? ModifiedDate { get; set; }
        public long? BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Books? Books { get; set; }
    }
}
