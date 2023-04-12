using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repositories
{
    public interface IEntityRepository<TEntity, TKey> : IRepository<TEntity>
        where TEntity : class
    {
        TEntity GetItem(TKey id);
        void Delete(TKey id);
    }
}
