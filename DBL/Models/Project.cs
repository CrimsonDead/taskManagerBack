using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DBL.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Title  { get; set; }
        public string ?Description { get; set; }
    }
}