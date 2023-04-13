using DBL.Models.Client;

namespace DBL.Models.Server
{
    public class UserModel : User
    {
        public ICollection<UserProjectModel> Projects { get; set; }
        public ICollection<UserJobModel> Jobs { get; set; }
    }
}