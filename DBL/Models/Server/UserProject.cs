using System.ComponentModel.DataAnnotations.Schema;

namespace DBL.Models.Server
{
    public class UserProject
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Project")]
        public string ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
