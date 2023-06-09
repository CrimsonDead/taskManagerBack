﻿using DBL.Models.Server;

namespace DBL.Models.Client
{
    public class JobCreateIn
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? EstimetedTime { get; set; } // In hours
        public double? SpentTime { get; set; }     // In hours
        public int Progress { get; set; }
        public JobStatus Status { get; set; }
        public string? JobRefId { get; set; }
        public string ProjectRefId { get; set; }
    }
}
