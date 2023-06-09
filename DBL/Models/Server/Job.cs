using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBL.Models.Server
{
    public class Job
    {
        [Key]
        public string JobId { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? EstimetedTime { get; set; } // In hours
        public double? SpentTime { get; set; }     // In hours
        public int Progress { get; set; }
        [Required]
        public JobStatus Status { get; set; }

        [ForeignKey("Job")]
        public string? JobRefId { get; set; }
        [ForeignKey("Project")]
        [Required]
        public string ProjectRefId { get; set; }

        public Job? ParentJob { get; set; }
        public Project Project { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public ICollection<UserJob> Users { get; set; }
    }
}
