using System.Threading.Tasks;
using Domain.Entities;

namespace BLL.Services.OrderService.Contracts
{
    public interface IDiscountService
    {
        void GetDiscount(Order order);
    }
}