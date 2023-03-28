namespace DBL.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetItems();
        T GetItem(int id);
        T AddItem(T item);
        T Update(T item);
        T Delete(T item);
    }
}