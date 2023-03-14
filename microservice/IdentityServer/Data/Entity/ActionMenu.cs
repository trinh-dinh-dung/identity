using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Data.Entity
{
    public class ActionMenu
    {
        [Key]
        public Guid Id { get; set; }
        public string ActionName { get; set; }
        public string ActionCodeApi { get; set; }
        public string ActionTitle { get; set; }
        public string PathName { get; set; }
        public bool IsActive { get; set; }
        public int Status { get; set; }
        public Guid MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu menu { get; set; }

    }
}
