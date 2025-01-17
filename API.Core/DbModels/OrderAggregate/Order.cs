﻿namespace API.Core.DbModels.OrderAggregate
{
	public class Order : BaseEntity
	{
        public Order()
        {
            
        }
        public Order(string buyerEmail, Address shipToAddress, DeliveryMethod deliveryMethod,
			IReadOnlyList<OrderItem> orderItems, decimal subTotal)

		{
			BuyerEmail = buyerEmail;
			ShipToAddress = shipToAddress;
			DeliveryMethod = deliveryMethod;
			OrderItems = orderItems;
			SubTotal = subTotal;

		}

		public string BuyerEmail { get; set; }
		public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
		public Address ShipToAddress { get; set; }
		public DeliveryMethod DeliveryMethod { get; set; }
		public IReadOnlyList<OrderItem> OrderItems { get; set; }
		public decimal SubTotal { get; set; }
		public OrderStatus Status { get; set; }
		public string PaymentIntendId { get; set; }

		public decimal GetTotal()
		{
			return SubTotal + DeliveryMethod.Price;

		}
	}
}
