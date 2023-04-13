﻿using DBL.Models.Client;
using DBL.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Models
{
    public static class ClientServerModelsMapping
    {
        public static JobModel Job2JobModel(Job job)
        {
            JobModel jobModel = new JobModel
            {
                Title = job.Title,
                Description = job.Description,
                StartDate = job.StartDate,
                EndDate = job.EndDate,
                EstimetedTime = job.EstimetedTime,
                SpentTime = job.SpentTime,
                Progreess = job.Progreess,
                Status = job.Status,
                JobRefId = job.JobRefId,
                ProjectRefId = job.ProjectRefId
            };

            return jobModel;
        }

        public static ProjectModel Project2ProjectModel(Project project)
        {
            ProjectModel projectModel = new ProjectModel
            {
                Title = project.Title,
                Description = project.Description,
            };

            return projectModel;
        }

    }
}
