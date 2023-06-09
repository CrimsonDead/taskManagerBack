using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DBL.Models.Server;
using Microsoft.AspNetCore.Identity;

namespace DBL.Contexts
{
    public class ApplicationContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<UserJob> UserJobs { get; set; }


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

            var ids = new Guid[] {Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()};

            builder.ApplyConfiguration(new ProjectContextConfiguration(ids));
            builder.ApplyConfiguration(new JobContextConfiguration(ids));
            builder.ApplyConfiguration(new UserProjectContextConfiguration());
            builder.ApplyConfiguration(new UserJobContextConfiguration());

            builder.Entity<Role>()
                .HasData(
                    new Role
                    {
                        Id = ids[1].ToString(),
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new Role
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Manager",
                        NormalizedName = "MANAGER"
                    },
                    new Role
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "User",
                        NormalizedName = "USER"
                    }
                );

            builder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = ids[2].ToString(),
                        UserName = "Admin",
                        Email = "Amin@a.min",
                        EmailConfirmed = true,
                        PhoneNumber = "123",
                    });

            builder.Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>
                    {
                        UserId = ids[2].ToString(),
                        RoleId = ids[1].ToString()
                    });
        }
    }
}