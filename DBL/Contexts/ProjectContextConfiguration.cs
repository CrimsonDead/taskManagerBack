using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DBL.Models.Server;

namespace DBL.Contexts
{
    internal class ProjectContextConfiguration : IEntityTypeConfiguration<Project>
    {
        private Guid[] _ids;
        public ProjectContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        private void SeedData(EntityTypeBuilder<Project> builder)
        {
            builder
                .HasData(
                    new Project
                    {
                        ProjectId = _ids[0].ToString(),
                        Title = "Вырубка леса в секторе 8",
                        Description = "Shadow fiend "
                    }
                );
        }

        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .HasKey(p => new { p.ProjectId });

            SeedData(builder);
        }
    }
}