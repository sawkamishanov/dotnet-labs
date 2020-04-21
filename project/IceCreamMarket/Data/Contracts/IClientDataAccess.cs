using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;

namespace Data.Contracts
{
    public interface IClientDataAccess
    {
        Task Create(Client client);
        Task Update(Client client);
        Task Delete(IClientIdentity identity);
        Task<Client> Get(IClientIdentity identity);
        Task<IEnumerable<Client>> Get();
    }
}