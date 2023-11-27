namespace MBCM_PWA.Client.Shared.Models
{
    public class userService
    {
        public int UserId { get; private set; }
        public string UserType { get; private set; }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }

        public void SetUserType(string userType)
        {
            UserType = userType;
        }
    }
}
