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
    public class TimeslotsController : ControllerBase
    {
        private readonly WalkinContext _context;

        public TimeslotsController(WalkinContext context)
        {
            _context = context;
        }

        // GET: api/Timeslots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Timeslot>>> GetTimeslots()
        {
          if (_context.Timeslots == null)
          {
              return NotFound();
          }
            return await _context.Timeslots.ToListAsync();
        }

        // GET: api/Timeslots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Timeslot>> GetTimeslot(int id)
        {
          if (_context.Timeslots == null)
          {
              return NotFound();
          }
            var timeslot = await _context.Timeslots.FindAsync(id);

            if (timeslot == null)
            {
                return NotFound();
            }

            return timeslot;
        }

        // PUT: api/Timeslots/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeslot(int id, Timeslot timeslot)
        {
            if (id != timeslot.Id)
            {
                return BadRequest();
            }

            _context.Entry(timeslot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeslotExists(id))
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

        // POST: api/Timeslots
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Timeslot>> PostTimeslot(Timeslot timeslot)
        // {
        //   if (_context.Timeslots == null)
        //   {
        //       return Problem("Entity set 'WalkinContext.Timeslots'  is null.");
        //   }
        //     _context.Timeslots.Add(timeslot);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetTimeslot", new { id = timeslot.Id }, timeslot);
        // }

        // DELETE: api/Timeslots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeslot(int id)
        {
            if (_context.Timeslots == null)
            {
                return NotFound();
            }
            var timeslot = await _context.Timeslots.FindAsync(id);
            if (timeslot == null)
            {
                return NotFound();
            }

            _context.Timeslots.Remove(timeslot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeslotExists(int id)
        {
            return (_context.Timeslots?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost("/AddTimeslot/{Walkin_Id}")]
        public void AddTimeslotForWalkinId(Timeslot time ,int Walkin_Id)
        {
            string ConnectString =_context.Database.GetDbConnection().ConnectionString;
        System.Console.WriteLine(ConnectString);
        using (MySqlConnection lconn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString))
        {   
                lconn.Open();
               
             using (MySqlCommand cmd = new MySqlCommand())
             {          
                 
                cmd.Connection = lconn;
                 cmd.CommandText = "AddTimeslotForWalkinId"; // The name of the Stored Proc
                 cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Proc
                 cmd.Parameters.AddWithValue("@Walkin_Id", Walkin_Id); 
                 cmd.Parameters.AddWithValue("@SlotDetails", time.SlotDetails);  
                  cmd.ExecuteNonQuery();
                 cmd.Connection.Close();
                 
                 }}
        }
    }
}
