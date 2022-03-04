using SOMIService.Models.Payment;

namespace SOMIService.Services.Payment
{
    public interface IPaymentService
    {
        public InstallmentModel CheckInstallments(string binNumber,decimal price);
        public PaymentResponseModel Pay(PaymentModel model);
    }
}
