using System;
using System.Threading.Tasks;
using BLL.Services.ClientService.Contracts;
using Data.Contracts;
using Domain.Entities;

namespace BLL.Services.ClientService.Implementations
{
    public class CreateClientService: ICreateClientService
    {
        private IClientDataAccess DataAccess { get; }
        
        public CreateClientService(IClientDataAccess dataAccess)
        {
            DataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }
        
        public async Task CreateClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            
            await DataAccess.Create(client);
        }
    }
}