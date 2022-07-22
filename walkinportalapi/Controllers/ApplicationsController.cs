using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using walkinportalapi.Data;
using walkinportalapi.Models;

namespace walkinportalapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly WalkinContext _context;

        public ApplicationsController(WalkinContext context)
        {
            _context = context;
        }

        // GET: api/Applications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        {
          if (_context.Applications == null)
          {
              return NotFound();
          }
          string sql = "Call walkinportals_db.GetAllApplications";
            return await _context.Applications.FromSqlRaw<Application>(sql).ToListAsync();

        }

        // GET: api/Applications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplication(int id)
        {
          if (_context.Applications == null)
          {
              return NotFound();
          }
            var application = await _context.Applications.FirstOrDefaultAsync(p=>p.Id==id);

            if (application == null)
            {
                return NotFound();
            }

            return application;
        }

        // PUT: api/Applications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutApplication(int id, Application application)
        // {
        //     if (id != application.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(application).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!ApplicationExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // // POST: api/Applications
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Application>> PostApplication(Application application)
        // {
        //   if (_context.Applications == null)
        //   {
        //       return Problem("Entity set 'WalkinContext.Applications'  is null.");
        //   }
        //     _context.Applications.Add(application);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetApplication", new { id = application.Id }, application);
        // }

        // DELETE: api/Applications/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteApplication(int Id)
        // {
        //     if (_context.Applications == null)
        //     {
        //         return NotFound();
        //     }
        //     var application = await _context.Applications.FirstOrDefaultAsync(p=>p.Id==Id);
        //     if (application == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Applications.Remove(application);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool ApplicationExists(int id)
        {
            return (_context.Applications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
