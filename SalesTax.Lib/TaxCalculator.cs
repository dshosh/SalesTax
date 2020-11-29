using System;

namespace SalesTax.Lib
{
    public interface ITaxCalculator
    {
        decimal TotalTax(IOrderItem item);
        decimal SalePrice(IOrderItem item);
    }

    public class TaxCalculator : ITaxCalculator
    {
        private const decimal SALETAX_RATE = 0.1M;
        private const decimal IMPORT_DUTY = 0.05M;
        private readonly Func<decimal, decimal> Round; // Rounding Strategy

        // Strategy pattern
        public TaxCalculator(Func<decimal, decimal> round)
        {
            Round = round;
        }

        public decimal TotalTax(IOrderItem item) => Round(SaleTax(item) + ImportTax(item));

        public decimal SalePrice(IOrderItem item) => item.Price + TotalTax(item);

        private decimal SaleTax(IOrderItem item) => !item.IsExempt() ? item.Price * SALETAX_RATE : 0M;

        private decimal ImportTax(IOrderItem item) => item.IsImported ? item.Price * IMPORT_DUTY : 0M;
    }
}
