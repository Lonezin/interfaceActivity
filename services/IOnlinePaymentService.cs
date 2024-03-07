namespace PaymentCompany.services
{
    public interface IOnlinePaymentService
    {
        double PaymentFee (double amount);
        double Interest(int months, double amount);        
    }
}