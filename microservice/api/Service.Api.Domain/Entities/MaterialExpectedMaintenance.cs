using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class MaterialExpectedMaintenance
    {
        public MaterialExpectedMaintenance()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public Guid Id { get; set; }

        public string Periodcode { get; set; }

        public string Materialcode { get; set; }

        public int? Qty { get; set; }

        public string Unit { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Period Period { get; set; }

        #endregion

    }
}
