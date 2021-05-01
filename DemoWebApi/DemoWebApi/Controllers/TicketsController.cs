using DemoWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {       
        private readonly ILogger<TicketsController> _logger;

        public TicketsController(ILogger<TicketsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]        
        public IActionResult Get()
        {
            return Ok("Reading all tickets");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading ticket #{id}");
        }

        [HttpPost]        
        public IActionResult Post([FromBody] Ticket ticket)
        {
            return Ok(ticket);
        }

        [HttpPut("{id}")]        
        public IActionResult Put(int id)
        {
            return Ok($"Updating a ticket #{id}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting ticket #{id}");
        }
    }
}
