namespace DBL.Models.Client
{
    public class UserItemReturn
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<ProjectListedReturn> Projects { get; set; }
        public List<JobListedReturn> Jobs { get; set; }
        
    }
}