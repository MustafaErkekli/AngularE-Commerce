namespace API.Core.DbModels.OrderAggregate
{
	public class OrderItem:BaseEntity
	{
        public OrderItem()
        {
            
        }
        public OrderItem(ProductItemOrdered ıtemOrdered, decimal price, decimal quantity)
		{
			ItemOrdered = ıtemOrdered;
			Price = price;
			Quantity = quantity;
		}

		public ProductItemOrdered ItemOrdered { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
