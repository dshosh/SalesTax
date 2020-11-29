using System.Collections.Generic;
using System.Linq;

namespace SalesTax.Lib
{
    // TODO: make a singleton, retrieve from a IoC container, etc.
    public static class TaxFreeRegistry
    {
        private static readonly List<string> _exemptItems = new List<string>();

        static TaxFreeRegistry()
        {
            _exemptItems.Add("book");
            _exemptItems.Add("chip");
            _exemptItems.Add("tablet"); // TODO: All Android tablets are now tax free :)
            _exemptItems.Add("panadol");
            _exemptItems.Add("milk");
        }

        public static void Add(string itemName)
        {
            _exemptItems.Add(itemName);
        }

        public static bool IsExempt(this IOrderItem item) => _exemptItems.Any(ex => item.Name.ToLower().Contains(ex));
    }
}
