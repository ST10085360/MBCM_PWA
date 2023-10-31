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

        // Assuming you want to establish a relationship with tblProject
        public List<Project> OwnedProjects { get; set; }
        public List<Project> VolunteerProjects { get; set; }
        public List<Review> Reviews { get; set; }
        public List<UserProjects> Projects { get; set; }
    }
}
