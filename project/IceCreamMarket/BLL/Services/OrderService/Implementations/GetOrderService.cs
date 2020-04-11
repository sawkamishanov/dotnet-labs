using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Services.OrderService.Repositories;
using Data.Repositories;
using Domain;
using Domain.Entities;

namespace BLL.Services.OrderService.Implementations
{
    public class GetOrderService: IGetOrderService
    {
        private IRepository<Order> DataAccess { get; }
        public GetOrderService(IRepository<Order> dataAccess)
        {
            DataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        public Task<Order> GetOrder(IEntityIdentity identity)
        {
            return DataAccess.Get(identity);
        }

        public Task<IEnumerable<Order>> GetOrder()
        {
            return DataAccess.Get();
        }
    }
}