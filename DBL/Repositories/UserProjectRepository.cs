using DBL.Contexts;
using DBL.Models.Server;

namespace DBL.Repositories
{
    public class UserProjectRepository : 
        IRelationEntityRepository<UserProjectModel, string, string>
    {
        private readonly ApplicationContext _context;

        public UserProjectRepository(ApplicationContext context)
        {
            _context = context;
        }

        public UserProjectModel AddItem(UserProjectModel item)
        {
            _context.UsersProjects.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(string userId, string projectId)
        {
            var item = GetItem(userId, projectId);
            _context.UsersProjects.Remove(item);
            _context.SaveChanges();
        }

        public UserProjectModel GetItem(string userId, string projectId)
        {
            return _context.UsersProjects.FirstOrDefault(
                up => up.UserId == userId && up.ProjectId == projectId
            );
        }

        public IEnumerable<UserProjectModel> GetItems()
        {
            return _context.UsersProjects.ToList();
        }

        public UserProjectModel Update(UserProjectModel item)
        {
            _context.UsersProjects.Update(item);
            return item;
        }
    }
}