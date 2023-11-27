using System.ComponentModel.DataAnnotations;

namespace MBCM_PWA.Client.Shared.Models
{
    public class UserProjects
    {
        [Key]
        public int userProjectID { get; set; }
        public int userID { get; set; }
        public int projectID { get; set; }

        // Navigation properties
        public Project Project { get; set; }
        public User User { get; set; }
    }
}