namespace DBL.Repositories
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        IEnumerable<TEntity> GetItems();
        TEntity AddItem(TEntity item);
        TEntity Update(TEntity item);
    }
}