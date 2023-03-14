using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class File
    {
        public File()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public Guid Id { get; set; }

        public int Type { get; set; }

        public string Url { get; set; }

        public int Tabletype { get; set; }

        public Guid Belongto { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Machine BelongtoMachine { get; set; }

        #endregion

    }
}
