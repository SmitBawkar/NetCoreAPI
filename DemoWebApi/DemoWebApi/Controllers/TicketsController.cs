using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Controllers
{
    [ApiController]    
    public class TicketsController : ControllerBase
    {       
        private readonly ILogger<TicketsController> _logger;

        public TicketsController(ILogger<TicketsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/tickets")]
        public IActionResult Get()
        {
            return Ok("Reading all tickets");
        }

        [HttpGet]
        [Route("api/tickets/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading ticket #{id}");
        }

        [HttpPost]
        [Route("api/tickets")]
        public IActionResult Post()
        {
            return Ok($"Creating a ticket");
        }

        [HttpPut]
        [Route("api/tickets/{id}")]
        public IActionResult Put(int id)
        {
            return Ok($"Updating a ticket #{id}");
        }

        [HttpDelete]
        [Route("api/tickets/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting ticket #{id}");
        }
    }
}
