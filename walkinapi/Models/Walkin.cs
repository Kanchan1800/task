using System.Collections.Generic;
namespace walkinapi.Models;
public class Walkin
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Duration { get; set; }
    public string[]? Roles { get; set; }
    public string? Location { get; set; }
    public string? General_instruc { get; set; }
    public string? System_req { get; set; }
    public string? ExpiresIn { get; set; }
    public string? Exam_instruc{ get; set; }
    public string? InternshipDetails { get; set; }
    //public int[]? Timeslot_id{get;set;}
    //public int[]? Roles_id{get;set;}
    public List<walkinapi.Models.Roles>? Role{get;set;}
    public System.Collections.Generic.List<walkinapi.Models.Timeslots>? Timeslot{get;set;}
}