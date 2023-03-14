using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class MaintenanceschedulePeriod
    {
        public MaintenanceschedulePeriod()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public Guid Id { get; set; }

        public string Maintenanceschedulecode { get; set; }

        public string Periodcode { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Maintenanceschedule Maintenanceschedule { get; set; }

        public virtual Period Period { get; set; }

        #endregion

    }
}
