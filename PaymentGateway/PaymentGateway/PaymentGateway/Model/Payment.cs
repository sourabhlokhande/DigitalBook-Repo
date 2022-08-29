using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Model
{
    public class Payment
    {
        public long PaymentId { get; set; }
        public string? Email { get; set; }
        public string? CreatedDate { get; set; } = DateTime.Now.ToString();
        public string? ModifiedDate { get; set; } = DateTime.Now.ToString();
        public long? BookId { get; set; }
    }
}
