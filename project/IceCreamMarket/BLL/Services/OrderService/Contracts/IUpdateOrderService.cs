using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;

namespace BLL.Services.OrderService.Contracts
{
    public interface IUpdateOrderService
    {
        Task UpdateOrder(Order order);
        Task DeleteOrder(IOrderIdentity identity);
    }
}