using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DBL.Models.Server;

namespace DBL.Contexts
{
    public class UserProjectContextConfiguration : IEntityTypeConfiguration<UserProjectModel>
    {
        public UserProjectContextConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<UserProjectModel> builder)
        {
            builder
                .HasKey(up => new { up.UserId, up.ProjectId });

            builder
                .HasOne(uj => uj.User)
                .WithMany(u => u.Projects)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(uj => uj.Project)
                .WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
