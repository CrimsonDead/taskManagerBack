using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DBL.Models.Server;

namespace DBL.Contexts
{
    public class ProjectContextConfiguration : IEntityTypeConfiguration<ProjectModel>
    {
        private Guid[] _ids;
        public ProjectContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        private void SeedData(EntityTypeBuilder<JobModel> builder)
        {
            builder
                .HasData(
                    new ProjectModel
                    {
                        ProjectId = _ids[0].ToString(),
                        Title = "ZXC lobby",
                        Description = "Shadow fiend "
                    }
                );
        }

        public void Configure(EntityTypeBuilder<ProjectModel> builder)
        {
            
        }
    }
}