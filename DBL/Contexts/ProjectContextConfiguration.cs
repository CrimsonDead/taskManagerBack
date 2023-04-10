using Microsoft.EntityFrameworkCore;
using DBL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBL.Contexts
{
    public class ProjectContextConfiguration : IEntityTypeConfiguration<Project>
    {
        private Guid[] _ids;
        public ProjectContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .HasData(
                    new Project 
                    {
                        ProjectId   = _ids[0].ToString(),
                        Title       = "ZXC lobby",
                        Description = "Shadow fiend "
                    }
                );
        }
    }
}