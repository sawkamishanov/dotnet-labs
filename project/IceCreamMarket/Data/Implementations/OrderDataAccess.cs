using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Context;
using Data.DataSources;
using Data.Contracts;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class OrderDataAccess: IOrderDataAccess
    {
        private DatabaseContext Context { get; }
        private IMapper Mapper { get; }

        public OrderDataAccess(DatabaseContext context, IMapper mapper)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Order> CreateOrder(Order item)
        {
            var result = await Context.AddAsync(Mapper.Map<OrderDataSource>(item));
            await Context.SaveChangesAsync();

            return Mapper.Map<Order>(result.Entity);
        }

        public async Task<bool> UpdateOrder(Order item)
        {
            var result = 
                await Context.Orders.FirstOrDefaultAsync(order => order.Id == item.OrderId);
            if (result != null)
            {
                Context.Orders.Update(result);
                await Context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> DeleteOrder(IOrderIdentity identity)
        {
            var result =
                await Context.Orders.FirstOrDefaultAsync(order => order.Id == identity.OrderId);

            if (result != null)
            {
                Context.Orders.Remove(result);
                await Context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<Order> Get(IOrderIdentity identity)
        {
            if (identity.OrderId.HasValue)
            {
                return Mapper.Map<Order>(await Context.Orders.
                    FirstOrDefaultAsync(order => order.Id == identity.OrderId));
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return Mapper.Map<IEnumerable<Order>>(await Context.Orders.ToListAsync());
        }
    }
}