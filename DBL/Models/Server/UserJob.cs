using System.ComponentModel.DataAnnotations.Schema;

namespace DBL.Models.Server
{
    public class UserJob
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Job")]
        public string JobId { get; set; }
        public Job Job { get; set; }
    }
}
