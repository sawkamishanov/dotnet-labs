using System.Threading.Tasks;
using Domain.Entities;

namespace BLL.Services.ClientService.Repositories
{
    public interface ICreateClientService
    {
        Task<Client> CreateClient();
    }
}