using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repositories
{
    public interface IRelationEntityRepository<TEntity, TKey1, TKey2> : IRepository<TEntity>
        where TEntity : class
    {
        TEntity GetItem(TKey1 id1, TKey2 id2);
        void Delete(TKey1 id1, TKey2 id2);
    }
}
