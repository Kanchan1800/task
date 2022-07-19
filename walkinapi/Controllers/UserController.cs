using walkinapi.Models;
using walkinapi.Services;
using Microsoft.AspNetCore.Mvc;


namespace learnwebapi.Controllers;

[ApiController] //attributes
[Route("[controller]")]
 
public class UserController : ControllerBase // this class derives from ControllerBase, the base class for working with HTTP requests in ASP.NET Core.
{
    public UserController()
    {
    }
       
        [HttpGet("admin/GetAllUsers")] 
        public ActionResult<List<User>> GetAll() =>
            UserService.GetAll();

    [HttpGet("admin/GetUserOfId/{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = UserService.Get(id);

        if(user == null)
            return NotFound();

        return user;
    }

    // POST action
    [HttpPost("/register")]
    public IActionResult Create(User user)
    {            
         UserService.Add(user);
    return CreatedAtAction(nameof(Create), new { id = user.UserId }, user);
    }

    // PUT action

        [HttpPut("/update/{id}")]
    public IActionResult Update(int id,User user)
    {
        // This code will update the pizza and return a result
         if (id != user.UserId)
        return BadRequest();
           
        var existingUser = UserService.Get(id);
        if(existingUser is null)
            return NotFound();
    
        UserService.Update(user);           
    
        return NoContent();     
    }

    // DELETE action

    [HttpDelete("/RemoveAccount/{id}")]
    public IActionResult Delete(int id)
    {
        // This code will delete the pizza and return a result
         var user = UserService.Get(id);
   
        if (user is null)
            return NotFound();
        
        UserService.Delete(id);
    
        return NoContent();
    }


   
    //  [HttpGet("/login/{email_id},{password}")]
    // public ActionResult<User> Get(String email_id ,string password)
    // {
    //     var user=UserService.IsValid(email_id,password);
    //     if(user is null)
    //         return NoContent();
    //     return user;
    // }

    [HttpPost("/login")]
    public bool? CreateNew(Login login)
    {            
         return UserService.IsValidUser(login.Email_Id,login.Password);
    
    //  if(user is null)
    //          return NoContent();
    //     return user;

    }



    [HttpPost("/apply/{user_id},{walkin_id}")]
    public string Apply(Applications app, int user_id,int walkin_id)
    {
        return UserService.AddNewApplication(app,user_id,walkin_id);
    //return CreatedAtAction(nameof(Apply), new { id = app.Application_Id }, app);

        

    }

    [HttpGet("/admin/AllApplicationsDetails")]
    public ActionResult<List<Applications>>  GetAllApplications()
    {
        return UserService.GetAllApplicationsDetails();
    }
    [HttpGet("/admin/GetApplicationsOfWalkinId/{id}")]
    public ActionResult<List<Applications>>  GetApplicationsOfWalkinId(int id)
    {
        return UserService.GetApplicationOfWalkinId(id);
    }



}