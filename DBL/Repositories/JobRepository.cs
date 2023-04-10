using DBL.Models;
using DBL.Contexts;

namespace DBL.Repositories
{
    public class JobRepository : IRepository<Job>
    {
        private readonly ApplicationContext _context;
        public JobRepository(ApplicationContext context)
        {
            _context = context;          
        }
        public Job AddItem(Job item)
        {
            _context.Jobs.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Job Delete(Job item)
        {
            _context.Jobs.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public Job GetItem(string id)
        {
            return _context.Jobs.FirstOrDefault(j => j.JobId == id);
        }

        public IEnumerable<Job> GetItems()
        {
            return _context.Jobs.ToList();
        }

        public Job Update(Job item)
        {
            _context.Jobs.Update(item);
            return item;
        }
    }
}