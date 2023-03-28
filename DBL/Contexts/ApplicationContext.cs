using Microsoft.EntityFrameworkCore;
using DBL.Models;

namespace DBL.Contexts
{
    class ApplicationContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var ids = new Guid[] {Guid.NewGuid(), Guid.NewGuid()};

            builder.ApplyConfiguration(new JobContextConfiguration(ids));
            builder.ApplyConfiguration(new ProjectContextConfiguration(ids));
        }
    }
}