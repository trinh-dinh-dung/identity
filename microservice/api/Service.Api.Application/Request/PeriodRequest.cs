using Evo.Mes.Sop.Application.Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{

    public class PeriodPagingRequest : PagingQuery
    {

    }

    public class InsertpPeriod
    {
        public InsertpPeriod()
        {
            MaterialExpectedMaintenanceRequests = new List<MaterialExpectedMaintenanceRequest>();
        }
        public string Periodcode { get; set; }
        public string Periodname { get; set; }
        public Guid? Machineid { get; set; }
        public int? Maintenancetype { get; set; } // loai bao duong
        public double? Perioddatetime { get; set; }
        public int? Periodunit { get; set; }
        public string Maintenancepurpose { get; set; }
        public double? Maintenancedateexpected { get; set; }
        public DateTime? Periodrootdate { get; set; }

        public List<MaterialExpectedMaintenanceRequest> MaterialExpectedMaintenanceRequests { get; set; }
    }

    public class MaterialExpectedMaintenanceRequest
    {
        public Guid Id { get; set; }
        public string Periodcode { get; set; }
        public string Materialcode { get; set; }
        public int? Qty { get; set; }
        public string Unit { get; set; }
    }


    public class UpdatepPeriod
    {
        public string Periodcode { get; set; }
        public string Periodname { get; set; }
        public Guid? Machineid { get; set; }
        public int? Maintenancetype { get; set; } // loai bao duong
        public double? Perioddatetime { get; set; }
        public int? Periodunit { get; set; }
        public string Maintenancepurpose { get; set; }
        public double? Maintenancedateexpected { get; set; }
        public DateTime? Periodrootdate { get; set; }

        public List<UpdateMaterialExpectedMaintenanceRequest> UpdateMaterialExpectedMaintenanceRequests { get; set; }
    }

    public class UpdateMaterialExpectedMaintenanceRequest
    {
        public Guid Id { get; set; }
        public string Periodcode { get; set; }
        public string Materialcode { get; set; }
        public int? Qty { get; set; }
        public string Unit { get; set; }
    }

}
