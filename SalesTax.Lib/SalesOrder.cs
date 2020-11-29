using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTax.Lib
{
    public class SalesOrder
    {
        private readonly List<IOrderItem> _items = new List<IOrderItem>();
        private readonly ITaxCalculator _calculator;

        // Visitor pattern
        // TODO: TaxCalculator should be created by a factory and injected from an IoC container.
        public SalesOrder(ITaxCalculator calculator)
        {
            _calculator = calculator;
        }

        public void Add(IOrderItem item) => _items.Add(item);

        public decimal TotalTax() => _items.Sum(item => _calculator.TotalTax(item));

        private decimal Total() => _items.Sum(item => _calculator.SalePrice(item));

        public override string ToString() => $"{PrintItems()}Sales Taxes: {TotalTax():C}\nTotal: {Total():C}";

        private string PrintItems() => _items.Aggregate(new StringBuilder(), (sb, item) => sb.Append($"{Format(item)}")).ToString();

        private string Format(IOrderItem item) => $"{item}: {_calculator.SalePrice(item):C}\n";
    }
}
