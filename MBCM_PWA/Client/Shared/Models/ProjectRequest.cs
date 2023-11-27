using System.ComponentModel.DataAnnotations;

namespace MBCM_PWA.Client.Shared.Models
{
    public class ProjectRequest
    {
        [Key]
        public int RequestID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; } // Add this line
        public bool IsAccepted { get; set; }

        // Assuming you want to establish a relationship with tblUser and tblProject
        public User User { get; set; }
        public Project Project { get; set; }
    }
}
