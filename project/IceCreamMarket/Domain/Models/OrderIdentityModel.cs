using Domain.Contracts;

namespace Domain.Models
{
    public class OrderIdentityModel: IOrderIdentity
    {
        public int? OrderId { get; }

        public OrderIdentityModel(int? orderId)
        {
            OrderId = orderId;
        }
    }
}