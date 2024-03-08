using System.Globalization;
using PaymentCompany.entities;
using PaymentCompany.services;

namespace Main
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (MM/dd/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double value = double.Parse(Console.ReadLine());
            Console.Write("Enter the number of installments: ");
            int installment = int.Parse(Console.ReadLine());
            
            Contract mycontract = new Contract(number, date, value);
            ContractService contractService = new ContractService(new Paypal());
            contractService.ProcessContract(mycontract, installment);

            foreach (Installment item in mycontract.Installments)
            {
                System.Console.WriteLine(item);                
            }
        }
    }
}