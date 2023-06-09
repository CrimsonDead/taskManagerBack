using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Models.Client
{
    public class ProjectItemReturn
    {
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }
        public int TaskNum { get; set; }
        public List<JobListedReturn> CreatedTasks { get; set; }
        public List<JobListedReturn> InProgressTasks { get; set; }
        public List<JobListedReturn> CompleteTasks { get; set; }
        public List<UserListedReturn> Users { get; set; }
    }
}
