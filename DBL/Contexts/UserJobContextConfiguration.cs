using DBL.Models.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBL.Contexts
{
    public class UserJobContextConfiguration : IEntityTypeConfiguration<UserJob>
    {
        public UserJobContextConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<UserJob> builder)
        {
            builder
                .HasKey(uj => new { uj.UserId, uj.JobId });

            builder
                .HasOne(uj => uj.User)
                .WithMany(u => u.Jobs)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(uj => uj.Job)
                .WithMany(j => j.Users)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
