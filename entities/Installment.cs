using System.Globalization;

namespace PaymentCompany.entities
{
    public class Installment
    {
    public double Amount { get; set; }
    public DateTime DueDate  { get; set; }

    public Installment(double amount, DateTime dueDate)
    {
        Amount = amount;
        DueDate = dueDate;
    }
        public override string ToString()
        {
            return $"{DueDate.ToString("MM/dd/yyyy")} - {Amount.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}