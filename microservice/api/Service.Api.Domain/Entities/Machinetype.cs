using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Machinetype
    {
        public Machinetype()
        {
            #region Generated Constructor
            Machines = new HashSet<Machine>();
            #endregion
        }

        #region Generated Properties
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool? Active { get; set; }

        public DateTime? Createdate { get; set; }

        public Guid? Createby { get; set; }

        public DateTime? Updatetime { get; set; }

        public Guid? Updateby { get; set; }

        public int? Isdelete { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<Machine> Machines { get; set; }

        #endregion

    }
}
