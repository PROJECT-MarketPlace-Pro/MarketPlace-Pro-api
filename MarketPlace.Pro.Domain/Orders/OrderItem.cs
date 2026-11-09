
using MarketPlace.Pro.Domain.Catalog;

namespace MarketPlace.Pro.Domain.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }

        public Item Item { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price => Item.Price * Quantity;
    }
}
