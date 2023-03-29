using Microsoft.EntityFrameworkCore;
using DBL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBL.Contexts
{
    public class ProjectContextConfiguration : IEntityTypeConfiguration<Job>
    {
        private Guid[] _ids;
        public ProjectContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Job> builder)
        {

        }
    }
}