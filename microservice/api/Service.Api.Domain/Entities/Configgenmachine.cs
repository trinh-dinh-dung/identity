using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Configgenmachine
    {
        public Configgenmachine()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public Guid Id { get; set; }

        public string Configname { get; set; }

        public string Prefix { get; set; }

        public string Suffix { get; set; }

        public int Length { get; set; }

        public int Lastnumber { get; set; }

        public int Forwhat { get; set; }

        public bool? Status { get; set; }

        public DateTime Createddate { get; set; }

        public Guid Createdby { get; set; }

        public DateTime? Updateddate { get; set; }

        public Guid? Updatedby { get; set; }

        public Guid? Machinetypeid { get; set; }

        #endregion

        #region Generated Relationships
        #endregion

    }
}
