using Core.Models;
using DataStore.EF;
using DemoWebApi.FIlters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Controllers
{
    [ApiController]    
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {       
        private readonly ILogger<TicketsController> _logger;        

        public TicketsController(BugsContext db)
        {
            DbContext = db;
        }

        private BugsContext DbContext { get; }

        #region GET
        [HttpGet]        
        public async Task<IActionResult> Get()
        {
            return Ok(await DbContext.Tickets.AsNoTracking().ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {            
            var ticket = await DbContext.Tickets.FindAsync(id);
            if (ticket != null)
                return Ok(ticket);
            else
                return NotFound($"TicketId {id} not found");                                        
        }
        #endregion

        #region POST        
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Post([FromBody] Ticket ticket)
        {
            await DbContext.Tickets.AddAsync(ticket);
            await DbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new {id=ticket.TicketId }, ticket);
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
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody]Ticket ticket)
        {
            if (id != ticket.TicketId)
                return BadRequest("Id should be same");

            DbContext.Entry(ticket).State = EntityState.Modified;
            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch
            {
                if (DbContext.Tickets.Find(id) == null)
                    return NotFound();

                throw;
            }
            return NoContent();
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ticket = DbContext.Tickets.Find(id);

            if (ticket == null)
                return NotFound();
            else
            {
                DbContext.Tickets.Remove(ticket);
                DbContext.SaveChanges();
            }
            return Ok(ticket);

        }
        #endregion
    }
}
