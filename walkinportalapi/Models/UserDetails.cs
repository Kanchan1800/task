using System;
using walkinportalapi.Models;
using System.ComponentModel.DataAnnotations;
namespace walkinportalapi.Models
{
    public class UserDetails
{
    
[Required]    public int Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email_Id { get; set; }
    public string? Password { get; set; }
    public long? PhoneNo { get; set; }
    public string? Status { get; set; }
    public string? PortfolioUrl{ get; set; }
    public bool? IsFresher { get; set; }
    public int? ExperienceYears { get; set; }
    public string? CurrentCtc { get; set; }
    public string? ExpectedCtc { get; set; }
    public bool? OnNoticePeriod{ get; set; }

    public string? NoticePeriodEnds { get; set; }

    public string? NoticeDuration{get;set;}

    public bool? AppliedBefore{get;set;}
    public string? RoleBefore{get;set;}
    public bool? GivenZeusTest{get;set;}
    public string? Qualification{get;set;}
    public int? Percentage{get;set;}
    public string? Stream{get;set;}
    public string? PassingYear{get;set;}
    public string? College{get;set;}
    public string? CollegeLocation{get;set;}
   
}
}