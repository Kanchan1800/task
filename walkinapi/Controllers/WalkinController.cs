using walkinapi.Models;
using walkinapi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.Net.Http.Headers;
namespace learnwebapi.Controllers;

[ApiController] //attributes
[Route("[controller]")]
 
public class WalkinController : ControllerBase // this class derives from ControllerBase, the base class for working with HTTP requests in ASP.NET Core.
{
    public WalkinController()
    {
    }
       
        [HttpGet("AllWalkins")] 
        public ActionResult<List<Walkin>> GetAll() =>
            WalkinService.GetAll();

    //[Authorize]
    [HttpGet("{id}")]
    public ActionResult<Walkin> Get(int id)
    {
        var walkin = WalkinService.Get(id);

        if(walkin == null)
            return NotFound();

        return walkin;
    }

    [HttpPost("AddNewWalkin")]
    public IActionResult Create(Walkin walkin)
    {            
         WalkinService.Add(walkin);
    return CreatedAtAction(nameof(Create), new { id = walkin.Id }, walkin);
    }

        [HttpPut("/UpdateWalkinDetails/{id}")]
    public IActionResult Update(int id,Walkin walkin)
    {
         if (id != walkin.Id)
        return BadRequest();
        var existingWalkin = WalkinService.Get(id);
        if(existingWalkin is null)
            return NotFound();
        WalkinService.Update(walkin);         
        return NoContent();     
    }

    [HttpDelete("/DeleteWalkinOfId/{id}")]
    public IActionResult Delete(int id)
    {
         var walkin = WalkinService.Get(id);
         if (walkin is null)
            return NotFound();
        WalkinService.Delete(id);
        return NoContent();
    }

    [HttpGet("/Alltimeslots")] 
    public ActionResult<List<Timeslots>> GetAllTimeslots() =>
        WalkinService.GetAllTimeslots();

    
    [HttpGet("{id}/TimeslotOfWalkin")] 
    public ActionResult<List<Timeslots>> GetAllTimeslotsOfWalkin(int id) =>
        WalkinService.GetAllTimeslotsOfWalkin(id);


    [HttpPost("/AddNewTimeslotForWalkin/{id}")]
    public IActionResult AddTimeslot(Timeslots timeslot,int id)
    {            
        WalkinService.AddTimeslot(timeslot,id);
        return CreatedAtAction(nameof(AddTimeslot), new { id = timeslot.Timeslots_Id}, timeslot);
    }

   [HttpGet("/roles")] 
    public ActionResult<List<Roles>> GetAllRoles() =>
        WalkinService.GetAllRoles();
    
    [HttpGet("/roles/{id}")]
    public ActionResult<List<Roles>> GetRolesOfWalkin(int id)
    {
        return WalkinService.GetRolesOfWalkin(id);
    }
     [HttpPost("/AddNewRolesForWalkin/{id}")]
   public IActionResult  AddRolesForWalkinId(Roles role,int id)
   {
       WalkinService.AddRolesForWalkinId(role,id);
        return CreatedAtAction(nameof(AddTimeslot), new { id = role.Roles_Id}, role);
   }
















    //  [HttpGet("{title},{id}")]
    // public ActionResult<Walkin> Get(String title ,int id)
    // {
    //     var walkin=WalkinService.IsValid(title,id);

    //     if(walkin is null)
    //         return NoContent();

    //     return walkin;
    // }

    //  [HttpPost("{title}")]
    // public ActionResult<Walkin> CreateNew(String title ,int id)
    // {            
    //      var walkin= WalkinService.IsValid(title,id);;
    // if(walkin is null)
    //         return NoContent();

    //     return walkin;
    // }

    // public IActionResult Authenticate(){

    //     var grandmaClaims=new List<Claim>()
    //     {
    //         new Claim(ClaimTypes.Name,"Bob"),
    //         new Claim(ClaimTypes.Email,"Bob@gmail.com"),
    //         new Claim("Gradma.Says","Very nice boy."),
    //     };
    //     var licenseClaims=new List<Claim>(){
    //           new Claim(ClaimTypes.Name,"Bob k foo"),
    //         new Claim("DrivingLicense","A+"),
    //     };
    //     var grandmaIdentity=new ClaimsIdentity(grandmaClaims,"Gradma Identity");
    //     var LicenseIdentity=new ClaimsIdentity(licenseClaims,"Government");
    //     var userPrincipal=new ClaimsPrincipal(new[]{grandmaIdentity,LicenseIdentity});
    //     HttpContext.SignInAsync(userPrincipal);
    //     return RedirectToAction("GetAll");
    // }
}