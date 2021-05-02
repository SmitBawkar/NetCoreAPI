using DemoWebApi.FIlters;
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

        #region GET
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
        #endregion

        #region POST
        [HttpPost]        
        public IActionResult Post([FromBody] Ticket ticket)
        {
            return Ok(ticket);
        }

        [HttpPost]
        [Route("/api/v2/tickets")]
        [EnsureEnterDateActionFilter]
        public IActionResult PostV2([FromBody] Ticket ticket)
        {
            //Apply filter to V2
            return Ok(ticket);
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]        
        public IActionResult Put(int id)
        {
            return Ok($"Updating a ticket #{id}");
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting ticket #{id}");
        }
        #endregion
    }
}
