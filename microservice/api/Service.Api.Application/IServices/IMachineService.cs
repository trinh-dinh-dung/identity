using Application.GetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evo.Mes.Sop.Application.Common.Models;
namespace Application.IServices
{
    public partial interface IService
    {
        Task<int> GetAllMaChine();
    }
}
