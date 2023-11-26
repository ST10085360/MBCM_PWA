namespace MBCM_PWA.Client.Shared.Models
{
    public class userService
    {
        public int UserId { get; private set; }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }
    }
}
