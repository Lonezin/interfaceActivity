
namespace PaymentCompany.services
{
    public class Paypal : IOnlinePaymentService
    {
        private const double FeePercentage = 0.02;
        private const double MonthInterest = 0.01;
        public double Interest(int months, double amount)
        {
            return amount * MonthInterest * months;
        }

        public double PaymentFee(double amount)
        {
            return amount * FeePercentage;
        }
    }
}