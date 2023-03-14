using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Machine
    {
        public Machine()
        {
            #region Generated Constructor
            BelongtoFiles = new HashSet<File>();
            Periods = new HashSet<Period>();
            Repairinfos = new HashSet<Repairinfo>();
            #endregion
        }

        #region Generated Properties
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Productioncompanyby { get; set; }

        public string Model { get; set; }

        public string Providedby { get; set; }

        public string Productionfrom { get; set; }

        public DateTime? Yearproduce { get; set; }

        public string Serinumber { get; set; }

        public string Unit { get; set; }

        public string Capacity { get; set; }

        public double? Price { get; set; }

        public int? Depreciationtime { get; set; }

        public int? Maintancetime { get; set; }

        public int? Status { get; set; }

        public Guid? WorkAreaId { get; set; }

        public Guid? Machinetype { get; set; }

        public double? Heigh { get; set; }

        public double? Width { get; set; }

        public double? Length { get; set; }

        public DateTime? Createddate { get; set; }

        public Guid? Createdby { get; set; }

        public Guid? Updateby { get; set; }

        public DateTime? Updatedate { get; set; }

        public int? Isdelete { get; set; }

        public string Unitdes { get; set; }

        public string Workareaname { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<File> BelongtoFiles { get; set; }

        public virtual Machinetype Machinetype1 { get; set; }

        public virtual ICollection<Period> Periods { get; set; }

        public virtual ICollection<Repairinfo> Repairinfos { get; set; }

        #endregion

    }
}
