using System;
using learnwebapi.Models;
namespace learnwebapi.Models
{
    public class User
{
    
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email_Id { get; set; }
    public string? Password { get; set; }
    public long? PhoneNo { get; set; }
    public string? Status { get; set; }
    public string[]? PreferredRoles { get; set; }
    public string? PortfolioUrl{ get; set; }
    public List<ProfessionallQualification>? Professional_Qualification{get; set;}
    public List<EducationallQualification>? Educational_Qualification{get; set;}
   
}
}