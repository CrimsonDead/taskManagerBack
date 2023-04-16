using DBL.Contexts;
using DBL.Models.Server;

namespace DBL.Repositories
{
    public class ProjectRepository : IEntityRepository<ProjectModel, string>
    {
        private readonly ApplicationContext _context;

        public ProjectRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ProjectModel AddItem(ProjectModel item)
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

        public ProjectModel GetItem(string id)
        {
            var item = _context.Projects.FirstOrDefault(p => p.ProjectId == id);

            item.Jobs = _context.Jobs.Where(j => j.ProjectRefId == item.ProjectId).ToList();
            item.Users = _context.UsersProjects.Where(up => up.ProjectId == item.ProjectId).ToList();

            return item;
        }

        public IEnumerable<ProjectModel> GetItems()
        {
            return _context.Projects.ToList();
        }

        public ProjectModel Update(ProjectModel item)
        {
            _context.Projects.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}