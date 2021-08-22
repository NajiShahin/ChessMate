using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services
{
    public interface ICRUDService<T, K>
    {
        Task<T[]> GetList();
        Task<K> GetNew();
        Task<K> Get(Guid id);
        Task Create(K item);
        Task Update(K item);
        Task Delete(Guid id);
    }
}
