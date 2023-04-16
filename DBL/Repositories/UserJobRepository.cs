using DBL.Contexts;
using DBL.Models.Server;

namespace DBL.Repositories
{
    public class UserJobRepository :
        IRelationEntityRepository<UserJobModel, string, string>
    {
        private readonly ApplicationContext _context;

        public UserJobRepository(ApplicationContext context)
        {
            _context = context;
        }

        public UserJobModel AddItem(UserJobModel item)
        {
            _context.UsersJobs.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(string userId, string JobId)
        {
            var item = GetItem(userId, JobId);
            _context.UsersJobs.Remove(item);
            _context.SaveChanges();
        }

        public UserJobModel GetItem(string userId, string JobId)
        {
            return _context.UsersJobs.FirstOrDefault(
                up => up.UserId == userId && up.JobId == JobId
            );
        }

        public IEnumerable<UserJobModel> GetItems()
        {
            return _context.UsersJobs.ToList();
        }

        public UserJobModel Update(UserJobModel item)
        {
            _context.UsersJobs.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}
