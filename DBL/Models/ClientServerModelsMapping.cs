using DBL.Models.Client;
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
                Progress = job.Progress,
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

        public static ProjectModel ClearLinks(this ProjectModel project)
        {
            if (project == null)
                return project;

            if (project.Jobs != null)
                foreach (var item in project.Jobs)
                {
                    item.ParentJob = null;
                    item.Project = null;
                    item.Jobs = null;
                    item.Users = null;
                }

            if (project.Users != null)
                foreach (var item in project.Users)
                {
                    item.User = null;
                    item.Project = null;
                }

            return project;
        }

        public static JobModel ClearLinks(this JobModel job)
        {
            if (job == null)
                return job;

            if (job.ParentJob != null)
            {
                job.ParentJob.ParentJob = null;
                job.ParentJob.Project = null;
                job.ParentJob.Jobs = null;
                job.ParentJob.Users = null;
            }

            if (job.Project != null)
            {
                job.Project.Jobs = null;
                job.Project.Users = null;
            }


            if (job.Jobs != null)
                foreach (var item in job.Jobs)
                {
                    item.ParentJob = null;
                    item.Project = null;
                    item.Jobs = null;
                    item.Users = null;
                }

            if (job.Users != null)
                foreach (var item in job.Users)
                {
                    item.User = null;
                    item.Job = null;
                }

            return job;
        }

        public static UserJobModel ClearLinks(this UserJobModel userJob)
        {
            if (userJob == null)
                return userJob;

            if (userJob.User != null)
            {
                userJob.User.Projects = null;
                userJob.User.Jobs = null;
            }

            if (userJob.Job != null)
            {
                userJob.Job.ParentJob = null;
                userJob.Job.Project = null;
                userJob.Job.Jobs = null;
                userJob.Job.Users = null;
            }

            return userJob;
        }

        public static UserProject ClearLinks(this UserProjectModel userProject)
        {
            if (userProject == null)
                return userProject;

            if (userProject.User != null)
            {
                userProject.User.Projects = null;
                userProject.User.Jobs = null;
            }

            if (userProject.Project != null)
            {
                userProject.Project.Jobs = null;
                userProject.Project.Users = null;
            }

            return userProject;
        }

    }
}
