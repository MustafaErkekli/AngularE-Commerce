using System.Runtime.Serialization;

namespace API.Core.DbModels.OrderAggregate
{
	public enum OrderStatus
	{
		[EnumMember(Value = "Pending")]
		Pending,

		[EnumMember(Value = "Payment Received")]
		PaymentReceived,

		[EnumMember(Value = "Payment Failed")]
		PaymentFailed,
	}
}
