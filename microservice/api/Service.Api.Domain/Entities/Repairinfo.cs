using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Repairinfo
    {
        public Repairinfo()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public Guid Id { get; set; }

        public Guid Machineid { get; set; }

        public Guid? DeclarantWorkerid { get; set; }

        public DateTime? DeclarationDate { get; set; }

        public string CorrectionReason { get; set; }

        public Guid? AcceptanceWorkerid { get; set; }

        public DateTime? AcceptanceDay { get; set; }

        public string AcceptanceVerification { get; set; }

        public int? MachineStateAfterRepair { get; set; }

        public decimal? Costs { get; set; }

        public string Machinecode { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Machine Machine { get; set; }

        #endregion

    }
}
