using System.ComponentModel.DataAnnotations;

namespace MBCM_PWA.Client.Shared.Models
{
    public class SuggestedProject
    {
        [Key]
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
