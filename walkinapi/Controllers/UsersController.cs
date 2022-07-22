using Microsoft.AspNetCore.Mvc;
using walkinapi.Models;
using walkinapi.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using MySql.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
// using MySql.Data.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.SqlServer;
// using Pomelo.EntityFrameworkCore.MySql;


namespace walkinapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DbEntities _context;
    public UsersController(DbEntities context)
    {
        _context = context;
    }

     [HttpGet("{id}")]
    public ActionResult<Users> Get(int Id)
    {
        var user = this._context.Users.FirstOrDefault(p => p.Id == Id);
        if(user == null)
            return NotFound();

        return user;
    }

    [HttpPost("api/login")]
    public bool? CreateNew(Login login)
    {            
         var user = this._context.Users.FirstOrDefault(p => p.Email_Id == login.Email_Id && p.Password == login.Password);
        if(user == null)
            return false;

        return true;
    }
    // [HttpGet]
    // public ActionResult<List<Users>> Get()
    // {
    //     var user = this._context.Users.ToList();
    //     if(user == null)
    //         return NotFound();

    //     return user;
    // }

    [HttpGet]
        public ActionResult<List<Users>> GetAll() 
    {
        List<Users> list;
        string sql = "Call walkinportals_db.GetAllUser";
        list = _context.Users.FromSqlRaw<Users>(sql).ToList();
        System.Diagnostics.Debugger.Break();
        return list;
    }
//  [HttpPost("/registerstoredprocedureuser")]
//     public ActionResult<List<Users>> RegisterStoredUser(int id)
//     {
//         List<Users> list;
//         //string sql = "Call Add(user.Firstname, user.Lastname, user.Email_Id,user.Password,user.PhoneNo ,user.Status, user.PortfolioUrl,user.Type, user.ExperienceYears,user.CurrentCtc, user.ExpectedCtc, user.OnNoticePeriod,user.NoticePeriodEnds,user.NoticeDuration,user.AppliedBefore,user.RoleBefore,user.GivenZeusTest,user.Percentage,user.College,user.Qualification,user.Stream,user.PassingYear,user.CollegeLocation)";
//         string sql="call walkinportals_db.GetUser(1)";
        
//         list= _context.Users.FromSqlRaw(sql).ToList();
        
        
//         System.Diagnostics.Debugger.Break();
//     return list;
//         //return CreatedAtAction(nameof(RegisterUser), new { id = user.Id }, user);
        
//     }

     [HttpPost]
    public IActionResult RegisterUser(Users user)
    {
        this._context.Users.Add(user);
        this._context.SaveChanges();

        return CreatedAtAction(nameof(RegisterUser), new { id = user.Id }, user);
    }

     [HttpPost("/tp")]
    public void RegisterUserDetails(UserDetails user)
    {
        //dynamic data = JObject.Parse(user);
        
    }

    [HttpGet("ProfessionalQualifications")]
    public ActionResult<List<ProfessionalQualification>> Get()
    {
        List<ProfessionalQualification> list;
        list = this._context.ProfessionalQualification.ToList();
    
        return list;
    }

    [HttpPost("api/apply/{walkin_id},{user_id}")]
    public IActionResult Apply(Applicationn app,int walkin_id,int user_id )
    {
        app.Walkin_Id=walkin_id;
        app.Users_Id=user_id;
        this._context.Application.Add(app);
        this._context.SaveChanges();

        return CreatedAtAction(nameof(RegisterUser), new { id = app.Id }, app);
    }

    [HttpGet("/api/Applications")]
    public ActionResult<List<Applicationn>> GetApplications()
    {
        var applications = this._context.Application.ToList();
        if(applications == null)
            return NotFound();

        return applications;
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


 }





