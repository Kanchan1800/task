namespace walkinapi.Models
{
public class ProfessionallQualification
{
    
    public int ProfessionalQualificationId { get; set; }
    public int Users_Id { get; set; }
    public string? ApplicantType { get; set; }
    public int? ExperienceYears { get; set; }
    public int? CurrentCtc { get; set; }
    public int? ExpectedCtc { get; set; }
    //public FamiliarTech? Familiar_Tech{ get; set; }
    public string[]? ExpertiseIn { get; set; }
    public bool? OnNoticePeriod{ get; set; }
    public DateTime? NoticePeriodEndsOn { get; set; }

    public string? NoticePeriodDuration{get;set;}

    public bool? AppliedBefore{get;set;}
    public string? ForWhichRole{get;set;}


}
}