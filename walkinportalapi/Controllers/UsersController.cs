using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using walkinportalapi.Data;
using System.Data;
using walkinportalapi.Models;
using MySql.Data.MySqlClient;

namespace walkinportalapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly WalkinContext _context;

        public UsersController(WalkinContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        // [HttpPost]
        // public async Task<ActionResult<User>> PostUser(User user)
        // {
        //   if (_context.Users == null)
        //   {
        //       return Problem("Entity set 'WalkinContext.Users'  is null.");
        //   }
        //     _context.Users.Add(user);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetUser", new { id = user.Id }, user);
        // }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        
        [HttpPost("/LoginUserStoredProcedure")]
        public bool LoginUserStoredProcedure(Login user)
        {
        bool result=false;
        using (MySqlConnection lconn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString))
        {   
                lconn.Open();
               
             using (MySqlCommand cmd = new MySqlCommand())
             {          
                 
                cmd.Connection = lconn;
                 cmd.CommandText = "ValidateUser"; // The name of the Stored Proc
                 cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Proc
                 cmd.Parameters.AddWithValue("@Email_Id", user.Email_Id); 
                 cmd.Parameters.AddWithValue("@Password", user.Password); 
                 cmd.Parameters.Add("@Result", MySql.Data.MySqlClient.MySqlDbType.Bit).Direction = ParameterDirection.Output;
                 cmd.ExecuteNonQuery();
                 result = Convert.ToBoolean(cmd.Parameters["@Result"].Value);
                 cmd.Connection.Close();
                 return result;
             }
        }
    }

[HttpPost("/RegisterUserStoredProcedure")]
    public void RegisterStoredUser(UserDetails user)
    {

        //var user = new List<Users>();
        string ConnectString =_context.Database.GetDbConnection().ConnectionString;
        System.Console.WriteLine(ConnectString);
        using (MySqlConnection lconn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString))
        {   
                lconn.Open();
               
             using (MySqlCommand cmd = new MySqlCommand())
             {          
                 
                cmd.Connection = lconn;
                 cmd.CommandText = "Add"; // The name of the Stored Proc
                 cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Proc
                 cmd.Parameters.AddWithValue("@Firstname", user.Firstname); 
                 cmd.Parameters.AddWithValue("@Lastname", user.Lastname); 
                 cmd.Parameters.AddWithValue("@Email_Id", user.Email_Id); 
                 cmd.Parameters.AddWithValue("@Password", user.Password); 
                 cmd.Parameters.AddWithValue("@PhoneNo", user.PhoneNo); 
                 cmd.Parameters.AddWithValue("@Status", user.Status); 
                 cmd.Parameters.AddWithValue("@PortfolioUrl", user.PortfolioUrl); 
                 cmd.Parameters.AddWithValue("@IsFresher", user.IsFresher); 
                 cmd.Parameters.AddWithValue("@ExperienceYears", user.ExperienceYears); 
                 cmd.Parameters.AddWithValue("@Current_Ctc", user.CurrentCtc); 
                 cmd.Parameters.AddWithValue("@Expected_Ctc", user.ExpectedCtc); 
                 cmd.Parameters.AddWithValue("@OnNoticePeriod", user.OnNoticePeriod); 
                  cmd.Parameters.AddWithValue("@NoticePeriodEnds", user.NoticePeriodEnds); 
                  cmd.Parameters.AddWithValue("@NoticeDuration", user.NoticeDuration); 
                 cmd.Parameters.AddWithValue("@AppliedBefore", user.AppliedBefore); 
                 cmd.Parameters.AddWithValue("@RoleBefore", user.RoleBefore); 
                 cmd.Parameters.AddWithValue("@GivenZeusTest", user.GivenZeusTest); 
                 cmd.Parameters.AddWithValue("@Percentage", user.Percentage); 
                 cmd.Parameters.AddWithValue("@College", user.College); 
                 cmd.Parameters.AddWithValue("@Qualification", user.Qualification); 
                 cmd.Parameters.AddWithValue("@Stream", user.Stream); 
                 cmd.Parameters.AddWithValue("@PassingYear", user.PassingYear); 
                 cmd.Parameters.AddWithValue("@CollegeLocation", user.CollegeLocation); 

                 System.Console.WriteLine(cmd);
                 cmd.ExecuteNonQuery();
                 cmd.Connection.Close();
             }
        }
    }

     [HttpPost("applyForWalkinStoredProcedure/{Walkin_id},{User_id}")]
    public IActionResult Apply(Applicationn app,int Walkin_id,int User_id )
    {
            string ConnectString =_context.Database.GetDbConnection().ConnectionString;
        System.Console.WriteLine(ConnectString);
        using (MySqlConnection lconn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString))
        {   
                lconn.Open();
               
             using (MySqlCommand cmd = new MySqlCommand())
             {          
                 
                cmd.Connection = lconn;
                 cmd.CommandText = "Applications"; // The name of the Stored Proc
                 cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Proc
                 cmd.Parameters.AddWithValue("@Resume", app.Resume); 
                 cmd.Parameters.AddWithValue("@Walkin_Id", Walkin_id); 
                 cmd.Parameters.AddWithValue("@Users_Id", User_id); 
                 cmd.Parameters.AddWithValue("@Timeslots_Id", app.Timeslots_Id); 
                  cmd.ExecuteNonQuery();
                 cmd.Connection.Close();
             }}
        return CreatedAtAction(nameof(Apply), new { id = app.Id }, app);
    }







    }
}
