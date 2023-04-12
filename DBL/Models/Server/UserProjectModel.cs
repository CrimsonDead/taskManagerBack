using DBL.Models.Client;
using System.ComponentModel.DataAnnotations;

namespace DBL.Models.Server
{
    public class UserProjectModel : UserProject
    {
        public UserModel User { get; set; }
        public ProjectModel Project { get; set; }
    }
}