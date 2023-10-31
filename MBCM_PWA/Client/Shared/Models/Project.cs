namespace MBCM_PWA.Client.Shared.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public int prjOwnerID { get; set; }
        public string prjTitle { get; set; }
        public string prjDescription { get; set; }
        public string prjLocation { get; set; }
        public DateTime prjStartDate { get; set; }

        /*public User Owner { get; set; }
        public List<UserProjects> ProjectUsers { get; set; }*/
    }
}
