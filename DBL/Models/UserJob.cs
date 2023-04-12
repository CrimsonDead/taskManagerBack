using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DBL.Models
{
    public class UserJob : IdentityUser
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Job")]
        public string JobId { get; set; }
    }
}