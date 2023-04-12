using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DBL.Models.Server;

namespace DBL.Contexts
{
    public class UserJobContextConfiguration : IEntityTypeConfiguration<UserJobModel>
    {
        public UserJobContextConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<UserJobModel> builder)
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
