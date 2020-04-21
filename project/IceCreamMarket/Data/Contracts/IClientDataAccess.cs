using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;

namespace Data.Contracts
{
    public interface IClientDataAccess
    {
        Task<Client> CreateClient(Client client);
        Task<bool> UpdateClient(Client client);
        Task<bool> DeleteClient(IClientIdentity identity);
        Task<Client> Get(IClientIdentity identity);
        Task<IEnumerable<Client>> Get();
    }
}