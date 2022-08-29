using ModelService.Data;
using ModelService.Model;

namespace ReaderApi.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string BuyBook(Payment payment)
        {
            try
            {
                _dbContext.PaymentTbl.Add(payment);
                _dbContext.SaveChanges();
                return $"Transaction Id : {payment.PaymentId} Payment Successfull";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<Books> GetBookDetails(Payment payment)
        {
            try
            {
                IEnumerable<Books> book = _dbContext.BookTbl.Where(b => b.BookId == payment.BookId);
                return book;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<Payment> GetPurchasedBook(Payment payment)
        {
            try
            {


                IEnumerable<Payment>  paymentHistory = _dbContext.PaymentTbl.Where(p => p.Email == payment.Email);
                return paymentHistory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CheckReader(Payment payment)
        {

            try
            {
                var data = _dbContext.PaymentTbl.Where(p => p.Email.Equals(payment.Email) && p.BookId == payment.BookId).Select(p => p.PaymentId);


                if (data.Any())
                {

                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
