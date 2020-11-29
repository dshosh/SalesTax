namespace SalesTax.Lib
{
    public interface IOrderItem
    {
        string Name { get; }
        decimal Price { get; }
        bool IsImported { get; }
    }


    class OrderItem : IOrderItem
    {
        public string Name { get; private set; }
        public bool IsImported { get; private set; }
        private decimal UnitPrice { get; set; }
        private int Quantity { get; set; }

        public OrderItem(int quantity, string name, decimal unitPrice, bool imported)
        {
            Name = name;
            UnitPrice = unitPrice;
            IsImported = imported;
            Quantity = quantity;
        }

        public decimal Price => Quantity * UnitPrice;

        public override string ToString() => $"{Quantity} {Name}";
    }
}
