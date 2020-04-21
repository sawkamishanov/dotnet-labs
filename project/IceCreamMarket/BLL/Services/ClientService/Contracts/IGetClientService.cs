using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;

namespace BLL.Services.ClientService.Contracts
{
    public interface IGetClientService
    {
        Task<Client> GetClient(IEntityIdentity identity);
        Task<IEnumerable<Client>> GetClient();
    }
}