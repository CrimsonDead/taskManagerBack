using DBL.Models.Client;
using System.ComponentModel.DataAnnotations;

namespace DBL.Models.Server
{
    public class UserJobModel : UserJob
    {
        public UserModel User { get; set; }
        public JobModel Job { get; set; }
    }
}