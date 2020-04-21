using System.Threading.Tasks;
using Domain.Entities;

namespace BLL.Services.OrderService.Repositories
{
    public interface IDiscountService
    {
        void GetDiscount(Order order);
    }
}