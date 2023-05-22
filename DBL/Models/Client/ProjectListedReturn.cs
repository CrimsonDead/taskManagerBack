using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Models.Client
{
    public class ProjectListedReturn
    {
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }
        public int TaskNum { get; set; }
        public int CreatedTaskNum { get; set; }
        public int InProgressTaskNum { get; set; }
        public int CompleteTaskNum { get; set; }

    }
}
