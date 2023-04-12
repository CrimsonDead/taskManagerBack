using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DBL.Models.Server;

namespace DBL.Contexts
{
    public class ApplicationContext : IdentityDbContext<UserModel>
    {
        public DbSet<JobModel> Jobs { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<UserJobModel> UsersJobs { get; set; }
        public DbSet<UserProjectModel> UsersProjects { get; set; }


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
            builder.ApplyConfiguration(new UserJobContextConfiguration());
            builder.ApplyConfiguration(new UserProjectContextConfiguration());


            builder.Entity<UserRoleModel>()
                .HasData(
                    new UserRoleModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Admin"
                    },
                    new UserRoleModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Manager"
                    },
                    new UserRoleModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "User"
                    }
                );

        }
    }
}