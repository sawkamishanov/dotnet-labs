using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;

namespace Data.Contracts
{
    public interface IOrderDataAccess
    {
        Task<Order> CreateOrder(Order order);
        Task<bool> UpdateOrder(Order order);
        Task<bool> DeleteOrder(IOrderIdentity identity);
        Task<Order> Get(IOrderIdentity identity);
        Task<IEnumerable<Order>> Get();
    }
}