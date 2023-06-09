using Microsoft.AspNetCore.Identity;

namespace DBL.Models.Server
{
    public class User : IdentityUser<string>
    {
        public ICollection<UserProject> Projects { get; set; }
        public ICollection<UserJob> Jobs { get; set; }
    }
}
