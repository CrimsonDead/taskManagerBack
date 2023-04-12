using DBL.Contexts;
using DBL.Models.Server;

namespace DBL.Repositories
{
    public class JobRepository : IEntityRepository<JobModel, string>
    {
        private readonly ApplicationContext _context;
        public JobRepository(ApplicationContext context)
        {
            _context = context;          
        }
        public JobModel AddItem(JobModel item)
        {
            _context.Jobs.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(string id)
        {
            var job = GetItem(id);
            _context.Jobs.Remove(job);
            _context.SaveChanges();
        }

        public JobModel GetItem(string id)
        {
            return _context.Jobs.FirstOrDefault(j => j.JobId == id);
        }

        public IEnumerable<JobModel> GetItems()
        {
            return _context.Jobs.ToList();
        }

        public JobModel Update(JobModel item)
        {
            _context.Jobs.Update(item);
            return item;
        }
    }
}