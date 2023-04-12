using DBL.Models;
using DBL.Contexts;

namespace DBL.Repositories
{
    public class UserProjectRepository : IRepository<Project>
    {
        private readonly ApplicationContext _context;

        public UserProjectRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Project AddItem(Project item)
        {
            throw new NotImplementedException();
        }

        public Project Delete(Project item)
        {
            throw new NotImplementedException();
        }

        public Project GetItem(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetItems()
        {
            throw new NotImplementedException();
        }

        public Project Update(Project item)
        {
            throw new NotImplementedException();
        }
    }
}