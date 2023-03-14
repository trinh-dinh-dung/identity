using Evo.Mes.Sop.Application.Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{

    public class MaintenancescheduleRequest : PagingQuery
    {

    }

    public class MaintenancescheduleSaveRequest
    {
        //public string maintenanceschedulecode { get; set; }
        public string MachineId { get; set; }
        public string MachinaName { get; set; }
        public List<string> Periodcode { get; set; }
        public DateTime? expected_datestart { get; set; }
        public DateTime? expected_dateend { get; set; }
    }




    public class CarryOutMaintenanceRequest
    {
        public CarryOutMaintenanceRequest()
        {
            Listconsumables = new List<consumables>();
        }
        public string Maintenanceschedulecode { get; set; }
        public string MachineId { get; set; }
        public string MachineCode { get; set; }
        public string MachinaName { get; set; }
        public DateTime? ImplementationDate { get; set; }
        public long ExecutionTime { get; set; }
        public List<consumables> Listconsumables { get; set; }
        public decimal Maintenance_Cost { get; set; }
        public string Workerid { get; set; }
    }


    public class consumables
    {
        public string MachineId { get; set; }
        public string Materialcode { get; set; }
        public string Unit { get; set; }
        public int ExpectedQuantity { get; set; }
        public int ActualQuantity { get; set; }
    }

    public class skipMaintenanceRequest
    {
        public string Maintenanceschedulecode { get; set; }
        public string note { get; set; }
    }
}
