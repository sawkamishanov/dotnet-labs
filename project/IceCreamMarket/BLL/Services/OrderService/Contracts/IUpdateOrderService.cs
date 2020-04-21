using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;

namespace BLL.Services.OrderService.Contracts
{
    public interface IUpdateOrderService
    {
        Task<bool> UpdateOrder(Order order);
        Task<bool> DeleteOrder(IOrderIdentity identity);
    }
}