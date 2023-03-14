using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class MachineTypeRequest
    {
        public Guid? MachineType { get; set; }
    }
    
    public class MachineRequest
    {
        public int dropDownType { get; set; }
        public Guid? MachineId { get; set; }
    }
    public class GetCodeRequest
    {
        public int forWhat { get; set; }
    }
    public class ErrorDuplicatedRequest
    {
        public int table { get; set; }
        public string fieldname { get; set; }
        public string valuecheck { get; set; }
        public string key { get; set; }
    }
}
