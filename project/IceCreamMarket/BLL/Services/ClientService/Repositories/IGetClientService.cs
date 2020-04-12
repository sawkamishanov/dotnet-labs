using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;

namespace BLL.Services.ClientService.Repositories
{
    public interface IGetClientService
    {
        Task<Client> GetClient(IEntityIdentity identity);
        Task<IEnumerable<Client>> GetClient();
    }
}