using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GetMap
{
    public class MaintenancescheduleGetMap
    {
        public string Maintenanceschedulecode { get; set; }
        public string MachineId { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public DateTime? ExpectedDatestart { get; set; }
        public DateTime? ExpectedDateend { get; set; }
        public DateTime? RealityStartTime { get; set; }
        public DateTime? RealityEndTime { get; set; }
        public int? PeriodMaintancetype { get; set; }
        public int? Status { get; set; }
        public Guid? Workerid { get; set; }
        public long? TimeNeededForActualImplementation { get; set; }
        public string StringPeriodCode { get; set; }
    }


    public class createCalendarRequest
    {
        public string MachineId { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public string PeriodCodes { get; set; }
        public int? PeriodMaintancetype { get; set; }
        public DateTime? ExpectedDatestart { get; set; }
        public DateTime? ExpectedDateend { get; set; }
    }

    public class MaintenancescheduleDetailt
    {
        public string Maintenanceschedulecode { get; set; }
        public string MachineId { get; set; }
        public string MachineCode { get; set; }
        public string MachinaName { get; set; }
        public DateTime? ImplementationDate { get; set; }
        public long? ExecutionTime { get; set; }
        public int? Maintenance_Cost { get; set; }
        public DateTime? expected_datestart { get; set; }
        public DateTime? expected_dateend { get; set; }
        public List<MaterialsConsumable> MaterialExpectedMaintenances { get; set; }
    }
    public class MaterialsConsumable
    {
        public string Materialcode { get; set; }
        public string Unit { get; set; }
        public int ExpectedQuantity { get; set; }
        public int ActualQuantity { get; set; }
    }


}
