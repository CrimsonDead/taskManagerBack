using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DBL.Models.Client;

namespace DBL.Models.Server
{
    public class JobModel : Job
    {
        [Key]
        public string JobId { get; set; }
        public JobModel? ParentJob { get; set; }
        public ProjectModel Project { get; set; }
        public ICollection<JobModel> Jobs { get; set; }
        public ICollection<UserJobModel> Users { get; set; }
    }
}