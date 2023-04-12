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

        private void SeedData(EntityTypeBuilder<Job> builder)
        {
            builder
                .HasData(
                    new Job
                    {
                        JobId           = Guid.NewGuid().ToString(),
                        Title           = "Pick Shadow Fiend",
                        Description     = "Pick Shadow Fiend as your opponent",
                        ProjectRefId    = _ids[0].ToString(),
                        StartDate       = DateTime.Now,
                        EndDate         = DateTime.Now + TimeSpan.FromHours(5.0f),
                        EstimetedTime   = 3.5d
                    }
                );
        }

        public void Configure(EntityTypeBuilder<Job> builder)
        {
            
        }
    }
}