using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using DBL.Models.Server;

namespace DBL.Models.Client
{
    public class User : IdentityUser
    {
        public ICollection<UserProjectModel> Projects { get; set; }
        public ICollection<UserJobModel> Jobs { get; set; }
    }
}