using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GetMap
{
    public class PeriodGetMap
    {
        public string Periodcode { get; set; }
        public string Periodname { get; set; }
        public int? Maintenancetype { get; set; }
        public double? Perioddatetime { get; set; }
        public int? Periodunit { get; set; }
        public string Maintenancepurpose { get; set; }
        public double? Maintenancedateexpected { get; set; }
        public DateTime? Periodrootdate { get; set; }
        public Guid? Machineid { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
    }


    public class PeriodDetailGetMap
    {
        public PeriodDetailGetMap()
        {
            MaterialExpectedMaintenanceGetMaps = new List<MaterialExpectedMaintenanceGetMap>();
        }
        public string Periodcode { get; set; }
        public string Periodname { get; set; }
        public int? Maintenancetype { get; set; }
        public double? Perioddatetime { get; set; }
        public int? Periodunit { get; set; }
        public string Maintenancepurpose { get; set; }
        public double? Maintenancedateexpected { get; set; }
        public DateTime? Periodrootdate { get; set; }
        public Guid? Machineid { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public List<MaterialExpectedMaintenanceGetMap> MaterialExpectedMaintenanceGetMaps { get; set; }
    }

    public class MaterialExpectedMaintenanceGetMap
    {
        public Guid Id { get; set; }
        public string Periodcode { get; set; }
        public string Materialcode { get; set; }
        public int? Qty { get; set; }
        public string Unit { get; set; }
    }
}
