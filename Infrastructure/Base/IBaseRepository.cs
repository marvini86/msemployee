
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MsEmployee.Infrastrucuture.Base
{
    public interface IBaseRepository<TEntity>: IDisposable where TEntity : class
    {
        Task Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(string id);
        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> Get();
    }
}
