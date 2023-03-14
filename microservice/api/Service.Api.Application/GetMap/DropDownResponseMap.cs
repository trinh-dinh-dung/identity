using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evo.Mes.Sop.Application.Common.Models;
using Evo.Mes.Sop.Application.Common.Query;
namespace Application.GetMap
{
    public class DropDownGetMap
    {
        public string label { get; set; }
        public string value { get; set; }
        public string name { get; set; }
        public string code { get; set; }

    }
    public class ErrorDuplicated
    {
        public string key { get; set; }
        public bool isError { get; set; }
    }
}
