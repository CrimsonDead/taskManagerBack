using DBL.Models.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBL.Contexts
{
    internal class JobContextConfiguration : IEntityTypeConfiguration<Job>
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
                        Title           = "Подготовка оборудования",
                        Description     = "Подготока транспорта и инструбемнов к вырубке",
                        ProjectRefId    = _ids[0].ToString(),
                        StartDate       = DateTime.Now,
                        EndDate         = DateTime.Now + TimeSpan.FromHours(5.0f),
                        EstimetedTime   = 3.5d
                    },
                    new Job
                    {
                        JobId = Guid.NewGuid().ToString(),
                        Title = "Вырубка",
                        Description = "Вырубка",
                        ProjectRefId = _ids[0].ToString(),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now + TimeSpan.FromHours(5.0f),
                        EstimetedTime = 3.5d
                    }
                );
        }

        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder
                .HasKey(j => new { j.JobId });

            builder
                .HasOne(j => j.Project)
                .WithMany(p => p.Jobs)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(j => j.ParentJob)
                .WithMany(j => j.Jobs)
                .OnDelete(DeleteBehavior.NoAction);

            SeedData(builder);
        }
    }
}