using System.Threading.Tasks;
using Domain;
using Domain.Entities;

namespace BLL.Services.OrderService.Contracts
{
    public interface IUpdateOrderService
    {
        Task UpdateOrder(Order order);
        Task DeleteOrder(IEntityIdentity identity);
    }
}