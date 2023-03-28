using Microsoft.EntityFrameworkCore;
using DBL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBL.Contexts
{
    public class JobContextConfiguration : IEntityTypeConfiguration<Job>
    {
        private Guid[] _ids;
        public JobContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            
        }
    }
}