using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DBL.Models.Server;

namespace DBL.Contexts
{
    public class JobContextConfiguration : IEntityTypeConfiguration<JobModel>
    {
        private Guid[] _ids;
        public JobContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        private void SeedData(EntityTypeBuilder<JobModel> builder)
        {
            builder
                .HasData(
                    new JobModel
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

        public void Configure(EntityTypeBuilder<JobModel> builder)
        {
            builder
                .HasOne(j => j.Project)
                .WithMany(p => p.Jobs)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(j => j.SubJob)
                .WithMany(j => j.Jobs)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}