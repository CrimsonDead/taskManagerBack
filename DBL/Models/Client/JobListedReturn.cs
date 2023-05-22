using DBL.Models.Server;

namespace DBL.Models.Client
{
    public class JobListedReturn
    {
        public string JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }
        public JobStatus Status { get; set; }
    }
}