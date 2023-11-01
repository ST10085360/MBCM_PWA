namespace MBCM_PWA.Client.Shared.Models
{
    public class SuggestedProject
    {
        public int Id { get; set; }

        // Reference the user who recommended the project
        public User Recommender { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public int Upvotes { get; set; }
    }
}
