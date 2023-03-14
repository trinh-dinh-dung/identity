using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GetMap
{
    public class MaintenanceRepairInfoGetMapPaging
    {
        public Guid Id { get; set; }
        public Guid? Machineid { get; set; }
        public string MachineCode { get; set; }
        public DateTime? DeclarationDate { get; set; }
        public DateTime? AcceptanceDay { get; set; }
        public Guid? DeclarantWorkerid { get; set; }
        public string DeclarantWorkerName { get; set; }
        public Guid? AcceptanceWorkerid { get; set; }
        public string AcceptanceWorkerName { get; set; }
        public decimal? Costs { get; set; }
    }

    public class MaintenanceRepairInfoGetMap
    {
        public Guid Id { get; set; }
        public Guid MachineId { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }

        public Guid WorkerId { get; set; }
        public DateTime DeclarationDate { get; set; }// ngay khai bao
        public string RepairReason { get; set; }// ly do
    }
    public class MaintenanceRepairInfoAcceptanceGetMap
    {
        public Guid Id { get; set; }
        public Guid MachineId { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }

        public Guid WorkerId { get; set; }
        public DateTime DeclarationDate { get; set; }// ngay khai bao
        public string RepairReason { get; set; }// ly do
        public Guid? AcceptanceWorkerid { get; set; }
        public DateTime? AcceptanceDay { get; set; }
        public string AcceptanceVerification { get; set; }
        public int? MachineStateAfterRepair { get; set; }
        public int ModalStatus { get; set; }
        public decimal? Costs { get; set; }
    }
    public class DeleteWorkunitMachineRequest
    {
        public object data { get; set; }
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public int status { get; set; }
    }
}
