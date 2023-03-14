using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evo.Mes.Sop.Application.Common.Query;
namespace Application.GetMap
{
    public class MachineTypeGetPagingRequest : PagingQuery
    {
    }
    public class MachineTypeGetMap
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool? Active { get; set; }
    }
    public class MachineTypeFormRequest
    {
        public Guid? Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public bool? Active { get; set; }
    }
}
