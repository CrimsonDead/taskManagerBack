using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DBL.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string Title  { get; set; }
        public string ?Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EstimetedTime { get; set; }
        public TimeSpan SpentTime { get; set; }
        public int Progreess { get; set; }
        public JobStatus Status { get; set; }

        [ForeignKey("Job")]
        public int ?JobRefId { get; set; }
        public Job? SubJob { get; set; }
        [ForeignKey("Project")]
        public int ProjectRefId { get; set; }
        public Project Project { get; set; }
    }
}