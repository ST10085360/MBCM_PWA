using System.ComponentModel.DataAnnotations;

namespace MBCM_PWA.Client.Shared.Models
{
    public class ProjectRequest
    {
        [Key]
        public int RequestID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        public bool IsAccepted { get; set; }

        public User User { get; set; }
        public Project Project { get; set; }
    }
}
