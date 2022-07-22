namespace walkinapi.Models
{
public class ProfessionalQualification
{
    
    public int Id { get; set; }
    public int Users_Id { get; set; }
    public bool? IsFresher { get; set; }
    public string? ExperienceYears { get; set; }
    public string? Current_Ctc { get; set; }
    public string? Expected_Ctc { get; set; }
    public bool? OnNoticePeriod{ get; set; }
    public string? NoticePeriodEnds { get; set; }

    public string? NoticeDuration{get;set;}

    public bool? AppliedBefore{get;set;}
    public string? RoleBefore{get;set;}
    public bool? GivenZeusTest{get;set;}

}
}