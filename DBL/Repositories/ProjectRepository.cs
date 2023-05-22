using DBL.Contexts;
using DBL.Models.Server;

namespace DBL.Repositories
{
    public class ProjectRepository : IEntityRepository<Project, string>
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

        public void Delete(string id)
        {
            var project = GetItem(id);
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        public Project GetItem(string id)
        {
            var item = _context.Projects.FirstOrDefault(p => p.ProjectId == id);

            item.Jobs = _context.Jobs.Where(j => 
                j.ProjectRefId == item.ProjectId &&
                j.JobRefId == null).ToList();

            item.Users = _context.UserProjects.Where(up => up.ProjectId == item.ProjectId).ToList();

            return item;
        }

        public IEnumerable<Project> GetItems()
        {
            var itemList = _context.Projects.ToList();

            foreach (var item in itemList)
            {
                item.Jobs = _context.Jobs.Where(j => 
                    j.ProjectRefId == item.ProjectId &&
                    j.JobRefId == null).ToList();
                item.Users = _context.UserProjects.Where(up => up.ProjectId == item.ProjectId).ToList();
            }

            return itemList;
        }

        public Project Update(Project item)
        {
            _context.Projects.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}
