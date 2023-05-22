using DBL.Models.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Contexts
{
    public class UserProjectContextConfiguration : IEntityTypeConfiguration<UserProject>
    {
        public UserProjectContextConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<UserProject> builder)
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
