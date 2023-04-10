using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DBL.Models
{
    public class Job
    {
        [Key]
        public string JobId { get; set; }
        [Required]
        public string Title  { get; set; }
        public string ?Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime ?EndDate { get; set; }
        public int ?EstimetedTime { get; set; } // In hours
        public int ?SpentTime { get; set; }     // In hours
        public int ?Progreess { get; set; }
        [Required]
        public JobStatus Status { get; set; }

        [ForeignKey("Job")]
        public int ?JobRefId { get; set; }
        [ForeignKey("Project")]
        [Required]
        public int ProjectRefId { get; set; }
    }
}