using DBL.Contexts;
using DBL.Models.Server;

namespace DBL.Repositories
{
    public class JobRepository : IEntityRepository<Job, string>
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

        public void Delete(string id)
        {
            var job = GetItem(id);
            _context.Jobs.Remove(job);
            _context.SaveChanges();
        }

        public Job GetItem(string id)
        {
            var item = _context.Jobs.FirstOrDefault(j => j.JobId == id);

            item.ParentJob = _context.Jobs.FirstOrDefault(j =>
                (j.JobRefId != null ||
                j.JobRefId != string.Empty) &&
                j.JobId == item.JobRefId);

            item.Project = _context.Projects.FirstOrDefault(p => p.ProjectId == item.ProjectRefId);
            item.Jobs = _context.Jobs.Where(j => j.JobRefId == item.JobId).ToList();
            item.Users = _context.UserJobs.Where(uj => uj.JobId == item.JobId).ToList();

            return item;
        }

        public IEnumerable<Job> GetItems()
        {
            return _context.Jobs.ToList();
        }

        public Job Update(Job item)
        {
            _context.Jobs.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}
