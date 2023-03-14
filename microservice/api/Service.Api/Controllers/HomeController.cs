using ApiService.Base;
using Application.GetMap;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ApiService.Controllers
{
    [Route("api/api-service/home")]
    [Authorize]
    [ApiController]
    public class HomeController : BaseController
    {
        private readonly IService _service;
        public HomeController(IService service)
        {
            _service = service;
        }
        [HttpGet("call-data")]
        public async Task<IActionResult> CallData(int dropDownType)
        {
            var response = await _service.GetAllMaChine();
            return Ok(new ResponseApi(response, true));
        }
    }
}
