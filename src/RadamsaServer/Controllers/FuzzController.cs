using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadamsaServer.Models;
using RadamsaServer.Services;

namespace RadamsaServer.Controllers
{
    [Route("Fuzz")]
    [Produces("application/json")]
    public class FuzzController : Controller
    {
        private RadamsaService _radamsaService;

        public FuzzController(RadamsaService radamsaService)
        {
            _radamsaService = radamsaService;
        }

        public IActionResult Fuzz([FromBody] FuzzRequest request)
        {
            try
            {
                var output = _radamsaService.GetFuzzedOutput(request);
                return Ok(output);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}