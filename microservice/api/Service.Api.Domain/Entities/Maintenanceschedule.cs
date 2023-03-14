using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Maintenanceschedule
    {
        public Maintenanceschedule()
        {
            #region Generated Constructor
            MaintenanceschedulePeriods = new HashSet<MaintenanceschedulePeriod>();
            MaterialsUsedForMaintenances = new HashSet<MaterialsUsedForMaintenance>();
            #endregion
        }

        #region Generated Properties
        public string Maintenanceschedulecode { get; set; }

        public DateTime? ExpectedDatestart { get; set; }

        public DateTime? ExpectedDateend { get; set; }

        public DateTime? RealityStartTime { get; set; }

        public DateTime? RealityEndTime { get; set; }

        public int? Status { get; set; }

        public Guid? Workerid { get; set; }

        public long? TimeNeededForActualImplementation { get; set; }

        public string Noteskipmaintance { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<MaintenanceschedulePeriod> MaintenanceschedulePeriods { get; set; }

        public virtual ICollection<MaterialsUsedForMaintenance> MaterialsUsedForMaintenances { get; set; }

        #endregion

    }
}
