using PaymentCompany.entities;
namespace PaymentCompany.services
{
    public class ContractService
    {
        private IOnlinePaymentService OnlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            OnlinePaymentService = onlinePaymentService;
        }        
        public void ProcessContract (Contract contrato, int months)
        {
            double basicQuota = contrato.TotalValue / months;
            for (int i = 1; i <= months; i++)
            {
                DateTime date = contrato.Date.AddMonths(i);
                double updateQuota = basicQuota + OnlinePaymentService.Interest(i, basicQuota);
                double fullQuota = OnlinePaymentService.PaymentFee(updateQuota);
                contrato.AddInstallment(new Installment(fullQuota, date));
            }
        }
    }
}