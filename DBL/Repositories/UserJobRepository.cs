using DBL.Contexts;
using DBL.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repositories
{
    public class UserJobRepository :
        IRelationEntityRepository<UserJob, string, string>
    {
        private readonly ApplicationContext _context;

        public UserJobRepository(ApplicationContext context)
        {
            _context = context;
        }

        public UserJob AddItem(UserJob item)
        {
            _context.UserJobs.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(string userId, string JobId)
        {
            var item = GetItem(userId, JobId);
            _context.UserJobs.Remove(item);
            _context.SaveChanges();
        }

        public UserJob GetItem(string userId, string JobId)
        {
            var item = _context.UserJobs.FirstOrDefault(
                up => up.UserId == userId && up.JobId == JobId
            );

            return item;
        }

        public IEnumerable<UserJob> GetItems()
        {
            return _context.UserJobs.ToList();
        }

        public UserJob Update(UserJob item)
        {
            _context.UserJobs.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}
