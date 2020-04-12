using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Services.ClientService.Repositories;
using Data.Repositories;
using Domain;
using Domain.Entities;

namespace BLL.Services.ClientService.Implementations
{
    public class GetClientService: IGetClientService
    {
        private IRepository<Client> DataAccess { get; }

        public GetClientService(IRepository<Client> dataAccess)
        {
            DataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        public async Task<Client> GetClient(IEntityIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            var result = await DataAccess.Get(identity);
            
            if (result == null)
            {
                throw new InvalidOperationException($"Not find by id: {identity.Id}");
            }

            return result;
        }

        public async Task<IEnumerable<Client>> GetClient()
        {
            return await DataAccess.Get();
        }
    }
}