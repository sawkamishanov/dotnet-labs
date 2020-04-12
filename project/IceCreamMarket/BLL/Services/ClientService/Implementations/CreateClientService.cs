using System;
using System.Threading.Tasks;
using BLL.Services.ClientService.Repositories;
using Data.Repositories;
using Domain.Entities;

namespace BLL.Services.ClientService.Implementations
{
    public class CreateClientService: ICreateClientService
    {
        private IRepository<Client> DataAccess { get; }
        
        public CreateClientService(IRepository<Client> dataAccess)
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