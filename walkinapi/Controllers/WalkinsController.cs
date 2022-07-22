using Microsoft.AspNetCore.Mvc;
using walkinapi.Models;
using walkinapi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
namespace walkinapi.Controllers;
using MySql.Data.MySqlClient;
using System.Data;

[ApiController]
[Route("api/[controller]")]
public class WalkinsController : ControllerBase
{
    private readonly DbEntities _context;
    public WalkinsController(DbEntities context)
    {
        _context = context;
    }

     [HttpGet("{id}")]
    public ActionResult<Walkins> Get(int Id)
    {
        var walkin = this._context.Walkin.FirstOrDefault(p => p.Id == Id);
        if(walkin == null)
            return NotFound();

        return walkin;
    }
    [HttpGet]
    public ActionResult<List<Walkins>> Get()
    {
        var walkin = this._context.Walkin.ToList();
        if(walkin == null)
            return NotFound();

        return walkin;
    }

// [HttpGet]
//     public ActionResult<List<Users>> GetAll() 
// {
//     List<Users> list;
//     string sql = "Call walkinportals_db.GetAllUser";
//     list = _context.Users.FromSqlRaw<Users>(sql).ToList();
//     System.Diagnostics.Debugger.Break();
//     return list;
// }
//  [HttpPost]
//     public IActionResult RegisterUser(UserDetails user)
//     {
//         List<Users> list;
//         string sql = "Call Add(user)";
//         list = _context.Users.FromSqlRaw<Users>(sql).ToList();
//         System.Diagnostics.Debugger.Break();

//         return CreatedAtAction(nameof(RegisterUser), new { id = user.Id }, user);
//     }

     [HttpPost]
    public IActionResult AddWalkin(Walkins walkin)
    {
        this._context.Walkin.Add(walkin);
        this._context.SaveChanges();

        return CreatedAtAction(nameof(AddWalkin), new { id = walkin.Id }, walkin);
    }

        [HttpGet("/AllWalkinsUsingStoredProcedure")]
        public ActionResult<List<Walkins>> GetAll() 
    {
        List<Walkins> list;
        string sql = "Call walkinportals_db.GetAllWalkins";
        list = _context.Walkin.FromSqlRaw<Walkins>(sql).ToList();
        System.Diagnostics.Debugger.Break();
        return list;
    }

    
[HttpPost("/GetWalkinOfIdStoredProcedure")]
    public List<Walkins> GetWalkinOfIdStoredProcedure(int Id)
    {
        List<Walkins> result =new List<Walkins>();;
        using (MySqlConnection lconn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString))
        {   
                lconn.Open();
               
             using (MySqlCommand cmd = new MySqlCommand())
             {          
                 
                cmd.Connection = lconn;
                 cmd.CommandText = "GetWalkinOfId"; // The name of the Stored Proc
                 cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Proc
                 cmd.Parameters.AddWithValue("@Id",Id); 
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    {
   
                                result.Add(
                                        new Walkins
                                            {
                                                    Id =(int)(reader[0]),
                                                    Title =(string)(reader[1]),
                                                    Duration =(string)(reader[2]),
                                                    Roles =(string)(reader[3]),
                                                    Location =(string)(reader[4]),
                                                    GeneralInstructions =(string)(reader[5]),
                                                    ExamInstructions =(string)(reader[6]),
                                                    SystemRequirements = (string)(reader[7]),
                                                    ExpiresIn =(string)(reader[8]),
                                                    InternshipDetaisl =(string)(reader[9])
                                            }
                                        

                                ); //I only used array as an example but you may use built in collections.
                            
                    }
                    reader.Close();
                 //cmd.ExecuteNonQuery();
                 cmd.Connection.Close();
                 return result;
             }
        }
    }
    
}