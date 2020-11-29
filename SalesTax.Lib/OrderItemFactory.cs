using System;

namespace SalesTax.Lib
{
    public static class OrderItemFactory
    {
        // Assumes that all input is in the format: <qty> <product> at <price>
        // If <product> contains the word 'imported' then the product is deemed to attract import tax
        // If it can't be parsed we return null.
        // If it can then we return a OrderItem, complete with tax information calculated.
        public static IOrderItem CreateItem(string input)
        {
            var words = input.Split(' ');
            // Must have at least 4 words:
            if (words.Length < 4)
            {
                return null;
            }

            try
            {
                var quantity = int.Parse(words[0]);
                var price = decimal.Parse(words[words.Length - 1]);
                var productName = string.Join(" ", words, 1, words.Length - 3);
                var isImported = productName.Contains("imported ");
                if (isImported)
                {
                    // Ensure the word imported appears at the front of the description
                    productName = "imported " + productName.Replace("imported ", "");
                }
                return new OrderItem(quantity, productName, price, isImported);
            }
            catch (FormatException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
        }
    }
}
