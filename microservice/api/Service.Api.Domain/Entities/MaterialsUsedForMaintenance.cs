using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class MaterialsUsedForMaintenance
    {
        public MaterialsUsedForMaintenance()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public string Maintenanceschedulecode { get; set; }

        public string Materialcode { get; set; }

        public int? Expectedquantity { get; set; }

        public string Unit { get; set; }

        public int? Actualquantity { get; set; }

        public Guid MachineId { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Maintenanceschedule Maintenanceschedule { get; set; }

        #endregion

    }
}
