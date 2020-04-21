using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Entities;

namespace BLL.Services.OrderService.Contracts
{
    public interface IOrderService
    {
        Task<Order> MakeOrder(Order order);
        Task<Order> GetOrder(IOrderIdentity identity);
        Task<IEnumerable<Order>> GetOrder();
    }
}