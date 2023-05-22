using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DBL.Models.Server
{
    public class Project
    {
        [Key]
        public string ProjectId { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }

        public List<Job> Jobs { get; set; }
        public ICollection<UserProject> Users { get; set; }

    }
}