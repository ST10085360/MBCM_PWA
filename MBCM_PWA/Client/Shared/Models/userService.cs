namespace MBCM_PWA.Client.Shared.Models
{
    public class userService
    {
        public int UserId { get; private set; }
        public string UserType { get; private set; }

        // Default value indicating no user logged in
        private int userId = -1; 


        public void SetUserId(int userId)
        {
            UserId = userId;
        }

        public void SetUserType(string userType)
        {
            UserType = userType;
        }

        public void ClearAuthentication()
        {
            SetUserId(-1); 
            SetUserType("Guest");
        }
    }
}
