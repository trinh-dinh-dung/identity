using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo.Mes.Sop.Application.Common.Query
{
    public class PagingQuery
    {
        public PagingQuery()
        {
            PageIndex = 1;
            PageSize = 10;
        }

        public string SearchTerm { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Page size is positive number only")]
        public int PageSize { get; set; }//limit
        [Range(1, int.MaxValue, ErrorMessage = "Page Index is positive number only")]
        public int PageIndex { get; set; }
        public Guid? UserId { get; set; }
    }
}
