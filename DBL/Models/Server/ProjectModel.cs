using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DBL.Models.Client;

namespace DBL.Models.Server
{
    public class ProjectModel : Project
    {
        [Key]
        public string ProjectId { get; set; }
        public ICollection<JobModel> Jobs { get; set; }
        public ICollection<UserProjectModel> Users { get; set; }
    }
}