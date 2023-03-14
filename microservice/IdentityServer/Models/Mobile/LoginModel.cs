namespace IdentityServer.Models.Mobile
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class datatoken
    {
        public string token { get; set; }
        public string refresh { get; set; }
        public int ExpiresIn { get; set; }
    }

    public class refreshTokenModelRequest
    {
        public string refreshToken { get; set; }
    }
    public class refreshTokenModelResponse
    {
        public string refresh { get; set; }
    }

}
