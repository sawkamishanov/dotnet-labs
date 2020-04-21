using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Context;
using Data.DataSources;
using Data.Contracts;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class ClientDataAccess: IRepository<Client>
    {
        private DatabaseContext Context { get; }
        private IMapper Mapper { get; }

        public ClientDataAccess(DatabaseContext context, IMapper mapper)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Create(Client item)
        {
            await Context.AddAsync(Mapper.Map<ClientDataSource>(item));
            await Context.SaveChangesAsync();
        }

        public async Task Update(Client item)
        {
            var result = 
                await Context.Clients.FirstOrDefaultAsync(client => client.Id == item.Id);
            if (result != null)
            {
                Context.Clients.Update(result);
                await Context.SaveChangesAsync();
            }
        }

        public async Task Delete(IEntityIdentity id)
        {
            var result =
                await Context.Clients.FirstOrDefaultAsync(client => client.Id == id.Id);

            if (result != null)
            {
                Context.Clients.Remove(result);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<Client> Get(IEntityIdentity id)
        {
            if (id.Id.HasValue)
            {
                return Mapper.Map<Client>(await Context.Clients.FirstOrDefaultAsync(client => client.Id == id.Id));
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<IEnumerable<Client>> Get()
        {
            return Mapper.Map<IEnumerable<Client>>(await Context.Clients.ToListAsync());
        }
    }
}