using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Period
    {
        public Period()
        {
            #region Generated Constructor
            MaintenanceschedulePeriods = new HashSet<MaintenanceschedulePeriod>();
            MaterialExpectedMaintenances = new HashSet<MaterialExpectedMaintenance>();
            #endregion
        }

        #region Generated Properties
        public string Periodcode { get; set; }

        public string Periodname { get; set; }

        public int? Maintenancetype { get; set; }

        public double? Perioddatetime { get; set; }

        public int? Periodunit { get; set; }

        public string Maintenancepurpose { get; set; }

        public double? Maintenancedateexpected { get; set; }

        public DateTime? Periodrootdate { get; set; }

        public Guid? Machineid { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Machine Machine { get; set; }

        public virtual ICollection<MaintenanceschedulePeriod> MaintenanceschedulePeriods { get; set; }

        public virtual ICollection<MaterialExpectedMaintenance> MaterialExpectedMaintenances { get; set; }

        #endregion

    }
}
