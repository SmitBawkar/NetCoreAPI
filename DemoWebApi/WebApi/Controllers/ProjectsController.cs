using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        [Route("/api/projects/{pid}/tickets")]
        public IActionResult GetProjectTickets(int pid, [FromQuery]int tid)
        {
            if(tid == 0)
                return Ok($"Reading all tickets from project#{pid}");

            return Ok($"Reading ticket#{tid} from project#{pid}");
        }
    }
}
