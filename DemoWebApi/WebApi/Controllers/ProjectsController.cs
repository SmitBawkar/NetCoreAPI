using Core.Models;
using DataStore.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public ProjectsController(BugsContext db)
        {
            DbContext = db;
        }

        private BugsContext DbContext { get; }

        [HttpGet]        
        public IActionResult GetAllProjects()
        {
            return Ok(DbContext.Projects.ToList());
        }

        [HttpGet("{id}")]        
        public IActionResult GetProjectById(int id)
        {
            var project = DbContext.Projects.Find(id);
            if (project == null)
                return NotFound();
            else
                return Ok(project);
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] Project project)
        {

            DbContext.Projects.Add(project);
            DbContext.SaveChanges();

            return CreatedAtAction(nameof(GetProjectById),
                new {id = project.ProjectId },
                project);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id,[FromBody] Project project)
        {
            if (id <= 0 || id != project.ProjectId)
                return BadRequest();

            DbContext.Entry(project).State = EntityState.Modified;
            try
            {
                DbContext.SaveChanges();
            }
            catch
            {
                if (DbContext.Projects.Find(id) == null)
                    return NotFound();

                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = DbContext.Projects.Find(id);

            if (project == null) return NotFound();

            DbContext.Projects.Remove(project);
            DbContext.SaveChanges();

            return Ok(project);
        }


        //[HttpGet]
        //[Route("/api/projects/{pid}/tickets")]
        //public IActionResult GetProjectTickets(int pid, [FromQuery]int tid)
        //{
        //    var proj = 
        //    if(tid == 0)
        //        return Ok($"Reading all tickets from project#{pid}");

        //    return Ok($"Reading ticket#{tid} from project#{pid}");
        //}
    }
}
