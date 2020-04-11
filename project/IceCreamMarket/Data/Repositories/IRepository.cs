using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task Create(T item);
        Task Update(T item);
        Task Delete(IEntityIdentity id);
        Task<T> Get(IEntityIdentity id);
        Task<IEnumerable<T>> Get();
    }
}