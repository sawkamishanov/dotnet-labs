using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace BLL.Services.ClientService.Repositories
{
    public interface IGetClientService
    {
        Task<Client> GetClient(int id);
        Task<IEnumerable<Client>> GetClient();
    }
}