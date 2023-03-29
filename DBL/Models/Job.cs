using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DBL.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string Title  { get; set; }
        public string Description { get; set; }
        
        [ForeignKey("Job")]
        public int JobRefId { get; set; }
        public Job? SubJob { get; set; }
        [ForeignKey("Project")]
        public int ProjectRefId { get; set; }
        public Project Project { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}