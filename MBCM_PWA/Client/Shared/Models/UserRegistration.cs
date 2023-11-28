namespace MBCM_PWA.Client.Shared.Models
{
    public class UserRegistration
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string PhoneNum { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        
        public string EmailValidationMessage { get; set; }
        public string FirstNameValidationMessage { get; set; }
        public string LastNameValidationMessage { get; set; }
        public string BioValidationMessage { get; set; }
        public string PhoneNumValidationMessage { get; set; }
        public string PasswordValidationMessage { get; set; }
        public string ConfirmPasswordValidationMessage { get; set; }
    }
}
