using System.Threading.Tasks;
using Domain.Entities;

namespace BLL.Services.OrderService.Repositories
{
    public interface IDiscountService
    {
        decimal GetDiscount(Order order);
    }
}