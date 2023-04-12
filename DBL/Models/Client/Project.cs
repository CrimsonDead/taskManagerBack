using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DBL.Models.Client
{
    public class Project
    {
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}