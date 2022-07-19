using learnwebapi.Models;
using learnwebapi.Services;
using Microsoft.AspNetCore.Mvc;


namespace learnwebapi.Controllers;

[ApiController] //attributes
[Route("[controller]")]
 
public class UserController : ControllerBase // this class derives from ControllerBase, the base class for working with HTTP requests in ASP.NET Core.
{
    public UserController()
    {
    }

    // GET all action
    //The first REST verb that you need to implement is GET, where a client can get all pizzas from the API. 
    //You can use the built-in [HttpGet] attribute to define a method that will return the pizzas from our service.
       
        [HttpGet] 
        public ActionResult<List<User>> GetAll() =>
            UserService.GetAll();

    // GET by Id action
    //The client might also want to request information about a specific pizza instead of the entire list. You can implement another GET action that requires an id parameter. 
    //You can use the built-in [HttpGet("{id}")] attribute to define a method that will return the pizzas from our service. 
    //The routing logic registers [HttpGet] (without id) and [HttpGet("{id}")] (with id) as two different routes. You can then write a separate action to retrieve a single item.

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = UserService.Get(id);

        if(user == null)
            return NotFound();

        return user;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(User user)
    {            
        // This code will save the pizza and return a result
        //this method returns an IActionResult response.

        //IActionResult lets the client know if the request succeeded and provides the ID of the newly created pizza. 
        //IActionResult does this by using standard HTTP status codes, so it can easily integrate with clients regardless of the language or platform they're running on.
         UserService.Add(user);
    return CreatedAtAction(nameof(Create), new { id = user.UserId }, user);
    }

    // PUT action

        [HttpPut("{id}")]
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

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // This code will delete the pizza and return a result
         var user = UserService.Get(id);
   
        if (user is null)
            return NotFound();
        
        UserService.Delete(id);
    
        return NoContent();
    }


   
     [HttpGet("{email_id},{password}")]
    public ActionResult<User> Get(String email_id ,string password)
    {
        var user=UserService.IsValid(email_id,password);

        if(user is null)
            return NoContent();

        return user;
    }

     [HttpPost("/login")]
    public ActionResult<User> CreateNew(Login login)
    {            
         var user= UserService.IsValid(login.Email_Id,login.Password);
    if(user is null)
            return NoContent();

        return user;
    }
}