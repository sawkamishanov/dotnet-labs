using System.Threading.Tasks;
using Domain.Entities;

namespace BLL.Services.ClientService.Contracts
{
    public interface ICreateClientService
    {
        Task<Client> CreateClient(Client client);
    }
}