using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;

namespace BLL.Services.OrderService.Repositories
{
    public interface IOrderService
    {
        Task MakeOrder(Order order);
        Task<Order> GetOrder(IEntityIdentity identity);
        Task<IEnumerable<Order>> GetOrder();
    }
}