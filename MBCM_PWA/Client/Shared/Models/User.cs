namespace MBCM_PWA.Client.Shared.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userBio { get; set; }
        public int userProjects { get; set; }
        public string userEmail { get; set; }
        public string userPhoneNumber { get; set; }
        public DateTime JoinedDate { get; set; }
        public string userType { get; set; }

        public UserCredentials UserCredentials { get; set; }
    }
}
