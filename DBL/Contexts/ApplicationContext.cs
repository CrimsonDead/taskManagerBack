using Microsoft.EntityFrameworkCore;
using DBL.Models;

namespace DBL.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var ids = new Guid[] {Guid.NewGuid(), Guid.NewGuid()};

            builder.ApplyConfiguration(new JobContextConfiguration(ids));
            builder.ApplyConfiguration(new ProjectContextConfiguration(ids));

        }
    }
}