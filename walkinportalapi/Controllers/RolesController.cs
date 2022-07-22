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
    public class RolesController : ControllerBase
    {
        private readonly WalkinContext _context;

        public RolesController(WalkinContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
          if (_context.Roles == null)
          {
              return NotFound();
          }
            return await _context.Roles.ToListAsync();
        }


        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(int id)
        {
            return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost("/AddRole/{Walkin_Id}")]
        public void AddTimeslotForWalkinId(Role role ,int Walkin_Id)
        {
            string ConnectString =_context.Database.GetDbConnection().ConnectionString;
        System.Console.WriteLine(ConnectString);
        using (MySqlConnection lconn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString))
        {   
                lconn.Open();
               
             using (MySqlCommand cmd = new MySqlCommand())
             {          
                 
                cmd.Connection = lconn;
                cmd.CommandText = "AddRoleForWalkinId"; // The name of the Stored Proc
                cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Proc
                cmd.Parameters.AddWithValue("@Walkin_Id", Walkin_Id); 
                cmd.Parameters.AddWithValue("@RoleTitle", role.RoleTitle);  
                cmd.Parameters.AddWithValue("@Package", role.Package); 
                cmd.Parameters.AddWithValue("@Description", role.Description); 
                cmd.Parameters.AddWithValue("@Requirements", role.Requirements); 
                cmd.Parameters.AddWithValue("@ProcessDescription", role.ProcessDescription); 
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                 
                 }}
        }
    }
}
