using DBL.Contexts;
using DBL.Models.Server;

namespace DBL.Repositories
{
    public class UserProjectRepository :
        IRelationEntityRepository<UserProject, string, string>
    {
        private readonly ApplicationContext _context;

        public UserProjectRepository(ApplicationContext context)
        {
            _context = context;
        }

        public UserProject AddItem(UserProject item)
        {
            _context.UserProjects.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(string userId, string projectId)
        {
            var item = GetItem(userId, projectId);
            _context.UserProjects.Remove(item);
            _context.SaveChanges();
        }

        public UserProject GetItem(string userId, string projectId)
        {
            return _context.UserProjects.FirstOrDefault(
                up => up.UserId == userId && up.ProjectId == projectId
            );
        }

        public IEnumerable<UserProject> GetItems()
        {
            return _context.UserProjects.ToList();
        }

        public UserProject Update(UserProject item)
        {
            _context.UserProjects.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}
