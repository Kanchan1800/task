using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using walkinportalapi.Data;
using walkinportalapi.Models;
using System.Data;
using MySql.Data.MySqlClient;

namespace walkinportalapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkinsController : ControllerBase
    {
        private readonly WalkinContext _context;

        public WalkinsController(WalkinContext context)
        {
            _context = context;
        }

        // GET: api/Walkins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Walkin>>> GetWalkins()
        {
          if (_context.Walkins == null)
          {
              return NotFound();
          }
            return await _context.Walkins.ToListAsync();
        }

        // GET: api/Walkins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Walkin>> GetWalkin(int id)
        {
          if (_context.Walkins == null)
          {
              return NotFound();
          }
            var walkin = await _context.Walkins.FindAsync(id);

            if (walkin == null)
            {
                return NotFound();
            }
            

            return walkin;
        }

        // PUT: api/Walkins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWalkin(int id, Walkin walkin)
        {
            if (id != walkin.Id)
            {
                return BadRequest();
            }

            _context.Entry(walkin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WalkinExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Walkins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Walkin>> PostWalkin(Walkin walkin)
        // {
        //   if (_context.Walkins == null)
        //   {
        //       return Problem("Entity set 'WalkinContext.Walkins'  is null.");
        //   }
        //     _context.Walkins.Add(walkin);
        //     //_context.Timeslots.Add(walkin.Timeslots);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetWalkin", new { id = walkin.Id }, walkin);
        // }

        // DELETE: api/Walkins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWalkin(int id)
        {
            if (_context.Walkins == null)
            {
                return NotFound();
            }
            var walkin = await _context.Walkins.FindAsync(id);
            if (walkin == null)
            {
                return NotFound();
            }

            _context.Walkins.Remove(walkin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WalkinExists(int id)
        {
            return (_context.Walkins?.Any(e => e.Id == id)).GetValueOrDefault();
        }

         [HttpGet("/walkin with time and role/{id}")]
        public  async Task<List<Walkin>>   GetWalkinWithTimeslots(int id)
        {
        //   if (_context.Walkins == null)
        //   {
        //       return NotFound();
        //   }
            //var walkin =  _context.Walkins.FindAsync(id);

            // if (walkin == null)
            // {
            //     return NotFound();
            // }
            var courses = await  _context.Walkins
                .Include(c => c.Timeslots)
                .Include(c=>c.RolesNavigation)
                 .AsNoTracking().ToListAsync();
            
                    // return View(await courses.ToListAsync());

            return courses;
            //return await courses.ToListAsync();
        }
        [HttpPost("/AddWalkin")]
        public void AddNewWalkin(WalkinDetails walkin)
        {
             string ConnectString =_context.Database.GetDbConnection().ConnectionString;
        System.Console.WriteLine(ConnectString);
        using (MySqlConnection lconn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString))
        {   
                lconn.Open();
             using (MySqlCommand cmd = new MySqlCommand())
             {          
                cmd.Connection = lconn;
                 cmd.CommandText = "AddWalkin"; // The name of the Stored Proc
                 cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Proc
                 cmd.Parameters.AddWithValue("@Title", walkin.Title); 
                 cmd.Parameters.AddWithValue("@Duration", walkin.Duration); 
                 cmd.Parameters.AddWithValue("@Roles", walkin.Roles); 
                 cmd.Parameters.AddWithValue("@Location", walkin.Location); 
                 cmd.Parameters.AddWithValue("@GeneralInstructions", walkin.GeneralInstructions); 
                 cmd.Parameters.AddWithValue("@ExamInstructions", walkin.ExamInstructions); 
                 cmd.Parameters.AddWithValue("@SystemRequirements", walkin.SystemRequirements); 
                 cmd.Parameters.AddWithValue("@ExpiresIn", walkin.ExpiresIn); 
                 cmd.Parameters.AddWithValue("@InternshipDetaisl", walkin.InternshipDetaisl); 
                 cmd.Parameters.AddWithValue("@SlotDetails", walkin.SlotDetails); 
                 cmd.Parameters.AddWithValue("@RoleTitle", walkin.RoleTitle); 
                 cmd.Parameters.AddWithValue("@Package", walkin.Package); 
                  cmd.Parameters.AddWithValue("@Description", walkin.Description); 
                  cmd.Parameters.AddWithValue("@Requirements", walkin.Requirements); 
                 cmd.Parameters.AddWithValue("@ProcessDescription", walkin.ProcessDescription); 
                    System.Console.WriteLine("hhii6");
                 System.Console.WriteLine(cmd);

                 cmd.ExecuteNonQuery();
                 cmd.Connection.Close();
             }
        }
        }



    }
}
