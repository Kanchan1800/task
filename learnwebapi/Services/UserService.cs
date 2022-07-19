using learnwebapi.Models;

namespace learnwebapi.Services;

public static class UserService
{

    static List<User>? Users { get; set;}
     static  List<ProfessionallQualification>? ProfessionalQualifications_ { get;set; }
     static List<EducationallQualification>? EducationalQualifications_{get; set;}
     static int nextId = 3;
    static UserService()
    {
        Users= new List<User>{
            new User{UserId=1,FirstName="Kanchan",LastName="Choudhari",Email_Id="kanuchoudhary2000@gmail.com",Password="12345",PhoneNo=9930291178,Status="Applied",
            PreferredRoles=new string[]{"Software Developer"}
             ,Professional_Qualification=ProfessionalQualifications_?.FindAll(p=>p.Users_Id==1)
            ,Educational_Qualification=EducationalQualifications_?.FindAll(p=>p.Users_Id==1)
            },


            new User{UserId=2,FirstName="Vaishnavi",LastName="Kulkarni",Email_Id="vaish2000@gmail.com",Password="12345",PhoneNo=9930291178,Status=" Not Applied",
            PreferredRoles=new string[]{"Software Developer"}
            ,Professional_Qualification=ProfessionalQualifications_?.FindAll(p=>p.Users_Id==2)
            ,Educational_Qualification=EducationalQualifications_?.FindAll(p=>p.Users_Id==2)  },

        };
        ProfessionalQualifications_=new List<ProfessionallQualification>{
           new ProfessionallQualification{ProfessionalQualificationId=1,Users_Id=1,ApplicantType="Fresher",ExperienceYears=0,AppliedBefore=false},
           new ProfessionallQualification{ProfessionalQualificationId=2,Users_Id=2,ApplicantType="Fresher",ExperienceYears=0,AppliedBefore=false}
        };
        EducationalQualifications_ = new List<EducationallQualification>
        {
           new EducationallQualification{EducationalQualificationId=1,Standard="B.E",Stream="CS",PassingYear="2022",College="RGIT",CollegeLocation="Andheri",Users_Id=1},
           new EducationallQualification{EducationalQualificationId=1,Standard="BSC",Stream="Statistics",PassingYear="2021",College="Ruia",CollegeLocation="Andheri",Users_Id=2}
        };
        
    }
    public static List<User>? GetAll() =>  Users;
     public static User? Get(int id) => Users?.FirstOrDefault(p => p.UserId == id);

    public static void Add(User user)
    {
        user.UserId = nextId++;
        Users.Add(user);
       // List<ProfessionalQualification> myAnythingList = (user.Professional_Qualification as IEnumerable<ProfessionalQualification>).Cast<ProfessionalQualification>().ToList();
        //Console.WriteLine(user.Professional_Qualification);
        // ProfessionalQualifications.Add(myAnythingList);
    }

    public static void Delete(int id)
    {
        var user = Get(id);
        if(user is null)
            return;

        Users.Remove(user);
    }

    public static void Update(User user)
    {
        var index = Users.FindIndex(p => p.UserId == user.UserId);
        if(index == -1)
            return;

        Users[index] = user;
    }
    
    public static User? IsValid(string Email_Id,string Password) => Users.FirstOrDefault(p => p.Email_Id == Email_Id && p.Password==Password);
}

