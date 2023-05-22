using DBL.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Models.Client
{
    public class JobItemReturn
    {
        public string JobId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? EstimetedTime { get; set; } // In hours
        public double? SpentTime { get; set; }     // In hours
        public int? Progress { get; set; }
        public JobStatus Status { get; set; }
        public string? JobRefId { get; set; }
        public string ProjectRefId { get; set; }
        public List<JobListedReturn> SubTasks { get; set; }
        public List<UserListedReturn> Users { get; set; }
    }
}
