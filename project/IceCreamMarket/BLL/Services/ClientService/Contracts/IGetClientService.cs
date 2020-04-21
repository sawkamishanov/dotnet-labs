using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Entities;

namespace BLL.Services.ClientService.Contracts
{
    public interface IGetClientService
    {
        Task<Client> GetClient(IClientIdentity identity);
        Task<IEnumerable<Client>> GetClient();
    }
}