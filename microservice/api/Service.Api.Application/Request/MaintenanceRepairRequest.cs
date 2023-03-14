using Evo.Mes.Sop.Application.Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{


    public class MaintenanceRepairRequest : PagingQuery
    {

    }
    public class AddInfoRepairRequest
    {
        public Guid MachineId { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }

        public Guid WorkerId { get; set; }
        public DateTime DeclarationDate { get; set; }// ngay khai bao
        public string RepairReason { get; set; }// ly do

    }
    public class UpdateInfoRepairRequest
    {
        public Guid Id { get; set; }
        public Guid MachineId { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }

        public Guid WorkerId { get; set; }
        public DateTime DeclarationDate { get; set; }// ngay khai bao
        public string RepairReason { get; set; }// ly do

    }

    public class AcceptanceAndRepairRequest
    {
        public Guid Id { get; set; }
        public Guid acceptance_workerid { get; set; }
        public DateTime acceptance_day { get; set; }
        public string acceptance_verification { get; set; }
        public int machine_state_after_repair { get; set; }
        public decimal Costs { get; set; }
    }
}
