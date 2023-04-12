using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DBL.Models
{
    public class UserProject : IdentityUser
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Project")]
        public string ProjectId { get; set; }
    }
}