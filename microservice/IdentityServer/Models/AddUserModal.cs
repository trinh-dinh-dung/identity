namespace IdentityServer.Models
{
    public class AddUserModal
    {

        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public bool Email { get; set; }
        public string PhoneNumber { get; set; }
        public int IsAdmin { get; set; }
        public string Address { get; set; }
        public int status { get; set; }


    }


    public class SaveUserModal
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string JobTitleId { get; set; }
        public string DepartmentId { get; set; }
        public bool IsAdmin { get; set; }
        public int EntityStatus { get; set; }

    }
}
