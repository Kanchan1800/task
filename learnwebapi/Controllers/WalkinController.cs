using learnwebapi.Models;
using learnwebapi.Services;
using Microsoft.AspNetCore.Mvc;


namespace learnwebapi.Controllers;

[ApiController] //attributes
[Route("[controller]")]
 
public class WalkinController : ControllerBase // this class derives from ControllerBase, the base class for working with HTTP requests in ASP.NET Core.
{
    public WalkinController()
    {
    }

    // GET all action
    //The first REST verb that you need to implement is GET, where a client can get all pizzas from the API. 
    //You can use the built-in [HttpGet] attribute to define a method that will return the pizzas from our service.
       
        [HttpGet] 
        public ActionResult<List<Walkin>> GetAll() =>
            WalkinService.GetAll();

    // GET by Id action
    //The client might also want to request information about a specific pizza instead of the entire list. You can implement another GET action that requires an id parameter. 
    //You can use the built-in [HttpGet("{id}")] attribute to define a method that will return the pizzas from our service. 
    //The routing logic registers [HttpGet] (without id) and [HttpGet("{id}")] (with id) as two different routes. You can then write a separate action to retrieve a single item.

    [HttpGet("{id}")]
    public ActionResult<Walkin> Get(int id)
    {
        var walkin = WalkinService.Get(id);

        if(walkin == null)
            return NotFound();

        return walkin;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Walkin walkin)
    {            
        // This code will save the pizza and return a result
        //this method returns an IActionResult response.

        //IActionResult lets the client know if the request succeeded and provides the ID of the newly created pizza. 
        //IActionResult does this by using standard HTTP status codes, so it can easily integrate with clients regardless of the language or platform they're running on.
         WalkinService.Add(walkin);
    return CreatedAtAction(nameof(Create), new { id = walkin.Id }, walkin);
    }

    // PUT action

        [HttpPut("{id}")]
    public IActionResult Update(int id,Walkin walkin)
    {
        // This code will update the pizza and return a result
         if (id != walkin.Id)
        return BadRequest();
           
        var existingWalkin = PizzaService.Get(id);
        if(existingWalkin is null)
            return NotFound();
    
        WalkinService.Update(walkin);           
    
        return NoContent();     
    }

    // DELETE action

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // This code will delete the pizza and return a result
         var walkin = WalkinService.Get(id);
   
        if (walkin is null)
            return NotFound();
        
        WalkinService.Delete(id);
    
        return NoContent();
    }
}