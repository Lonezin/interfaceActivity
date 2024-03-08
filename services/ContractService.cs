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
        public void ProcessContract(Contract contrato, int months)
        {
            double basicQuota = contrato.TotalValue / months;
            for (int i = 1; i <= months; i++)
            {
                DateTime date = contrato.Date.AddMonths(i);
                double updateQuota = OnlinePaymentService.Interest(i, basicQuota);
                double fullQuota = basicQuota + updateQuota;
                // Aplicar a taxa de pagamento após o cálculo dos juros
                fullQuota += OnlinePaymentService.PaymentFee(fullQuota);
                contrato.AddInstallment(new Installment(fullQuota, date));
            }
        }
    }
}