namespace DBL.Models.Client
{
    public class UserLoginReturn
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Hash { get; set; }
        public List<ProjectListedReturn> Projects { get; set; }
        public List<JobListedReturn> Jobs { get; set; }
    }
}
