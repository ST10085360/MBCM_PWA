using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MBCM_PWA.Client.Shared.Models
{
    public class UserCredentials
    {
        [Key]
        [ForeignKey("User")]
        public int UserID { get; set; }

        public string HashedPassword { get; set; }
        
        public User User { get; set; }
    }
}
