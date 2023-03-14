namespace IdentityServer.Models.Account
{
    public class ResetPassword
    {
        public string Id { get; set; }
        public string AccountName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}
