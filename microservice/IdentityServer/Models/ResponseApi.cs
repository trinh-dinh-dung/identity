namespace IdentityServer.Models
{
    public class ResponseApi
    {
        public int Status { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }
        public object DataNew { get; set; }
        public string Message { get; set; }

        public string MesageStatus { get; set; }
    }
}
