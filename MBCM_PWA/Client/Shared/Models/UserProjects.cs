using System.ComponentModel.DataAnnotations;

namespace MBCM_PWA.Client.Shared.Models
{
    public class UserProjects
    {
        [Key]
        public int userProjectID { get; set; }
        public int userID { get; set; }
        public int projectID { get; set; }

        // Assuming you want to establish a relationship with tblUser and tblProject
        public User User { get; set; }
        public User Project { get; set; }
    }
}
