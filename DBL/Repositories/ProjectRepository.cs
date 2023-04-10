using DBL.Models;
using DBL.Contexts;

namespace DBL.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly ApplicationContext _context;

        public ProjectRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Project AddItem(Project item)
        {
            _context.Projects.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Project Delete(Project item)
        {
            _context.Projects.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public Project GetItem(string id)
        {
            return _context.Projects.FirstOrDefault(p => p.ProjectId == id);
        }

        public IEnumerable<Project> GetItems()
        {
            return _context.Projects.ToList();
        }

        public Project Update(Project item)
        {
            _context.Projects.Update(item);
            return item;
        }
    }
}