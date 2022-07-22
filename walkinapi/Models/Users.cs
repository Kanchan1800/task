using System;
using walkinapi.Models;
using System.ComponentModel.DataAnnotations;
namespace walkinapi.Models
{
    public class Users
{
    
[Required]    public int Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email_Id { get; set; }
    public string? Password { get; set; }
    public long? PhoneNo { get; set; }
    public string? Status { get; set; }
    public string? PortfolioUrl{ get; set; }
   
}
}