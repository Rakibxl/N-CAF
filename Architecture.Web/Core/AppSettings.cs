namespace Architecture.Web.Core
{
    public class AppSettings
    {
        public string TokenSecretKey { get; set; }
        public int TokenExpiresHours { get; set; }
        public string UserDefaultPassword { get; set; }
        public string AppHeaderSecretKey { get; set; } 
        public string AppRegistrationOTP { get; set; } 
    }
}