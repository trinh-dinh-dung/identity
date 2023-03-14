
using Application.GetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Evo.Mes.Sop.Application.Common.Models;
using Evo.Mes.Sop.Application.Common.Status;
using System.Text.RegularExpressions;
using Evo.Mes.Sop.Application.Exceptions;
using ClosedXML.Excel;
using System.IO;
using Domain.Entities;

namespace Application.Services
{
    public partial class Service
    {
        public async Task<int> GetAllMaChine()
        {
            return 1;
        }
    }
}
