using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Services.ClientService.Contracts;
using Data.Contracts;
using Domain;
using Domain.Contracts;
using Domain.Entities;

namespace BLL.Services.ClientService.Implementations
{
    public class GetClientService: IGetClientService
    {
        private IClientDataAccess DataAccess { get; }

        public GetClientService(IClientDataAccess dataAccess)
        {
            DataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        public async Task<Client> GetClient(IClientIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            var result = await DataAccess.Get(identity);
            
            if (result == null)
            {
                throw new InvalidOperationException($"Not find by id: {identity.ClientId}");
            }

            return result;
        }

        public async Task<IEnumerable<Client>> GetClient()
        {
            return await DataAccess.Get();
        }
    }
}