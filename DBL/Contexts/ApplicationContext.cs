using Microsoft.EntityFrameworkCore;
using DBL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DBL.Contexts
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            if (Database.EnsureCreated())
            {
                Database.Migrate();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var ids = new Guid[] {Guid.NewGuid()};

            builder.ApplyConfiguration(new ProjectContextConfiguration(ids));

            builder.ApplyConfiguration(new JobContextConfiguration(ids));


        }
    }
}