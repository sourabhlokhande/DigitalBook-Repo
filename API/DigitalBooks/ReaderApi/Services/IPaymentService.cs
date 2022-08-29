using ModelService.Model;

namespace ReaderApi.Services
{
    public interface IPaymentService
    {
        string BuyBook(Payment payment);
        IEnumerable<Payment> GetPurchasedBook(Payment payment);
        IEnumerable<Books> GetBookDetails(Payment payment);
        bool CheckReader(Payment payment);
    }
}