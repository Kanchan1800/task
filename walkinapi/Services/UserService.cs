using walkinapi.Models;

namespace walkinapi.Services;

public static class UserService
{

    static List<User>? Users { get; set;}
     static  List<ProfessionallQualification>? ProfessionalQualifications_ { get;set; }
     static List<EducationallQualification>? EducationalQualifications_{get; set;}
     static List<Applications>? Applications_ { get; set;}
     static int nextId = 3;
     static int nextIdEducationalQualifications_ =3;
     static int nextIdProfessionalQualifications_=3;
     static int nextapp=2;
    static UserService()
    {
        Applications_ = new List<Applications>{
            new Applications{Application_Id=1,Preference=new string[]{"qa"},Resume="resume.pdf",Walkin_Id=1,Users_Id=1,Timeslots_Id=1}
        };

        Users= new List<User>{
            new User{UserId=1,FirstName="Kanchan",LastName="Choudhari",Email_Id="kanuchoudhary2000@gmail.com",Password="12345",PhoneNo=9930291178,Status="Applied",
            PreferredRoles=new string[]{"Software Developer"}
            // ,Professional_Qualification=ProfessionalQualifications_?.FindAll(p=>p.Users_Id==1)
            //,Educational_Qualification=EducationalQualifications_?.FindAll(p=>p.Users_Id==1)
            },


            new User{UserId=2,FirstName="Vaishnavi",LastName="Kulkarni",Email_Id="vaish2000@gmail.com",Password="12345",PhoneNo=9930291178,Status=" Not Applied",
            PreferredRoles=new string[]{"Software Developer"}},
           // ,Professional_Qualification=ProfessionalQualifications_?.FindAll(p=>p.Users_Id==2)
           // ,Educational_Qualification=EducationalQualifications_?.FindAll(p=>p.Users_Id==2)  },

        };
        ProfessionalQualifications_=new List<ProfessionallQualification>{
           new ProfessionallQualification{ProfessionalQualificationId=1,Users_Id=1,ApplicantType="Fresher",ExperienceYears=0,AppliedBefore=false},
           new ProfessionallQualification{ProfessionalQualificationId=2,Users_Id=2,ApplicantType="Fresher",ExperienceYears=0,AppliedBefore=false}
        };
        EducationalQualifications_ = new List<EducationallQualification>
        {
           new EducationallQualification{EducationalQualificationId=1,Standard="B.E",Stream="CS",PassingYear="2022",College="RGIT",CollegeLocation="Andheri",Users_Id=1},
           new EducationallQualification{EducationalQualificationId=2,Standard="BSC",Stream="Statistics",PassingYear="2021",College="Ruia",CollegeLocation="Andheri",Users_Id=2}
        };
        
    }
    public static List<User>? GetAll() =>  Users;
     public static User? Get(int id){
            var user=   Users?.FirstOrDefault(p => p.UserId == id);
       user.Educational_Qualification=EducationalQualifications_.FindAll(p=>p.Users_Id==user.UserId);
         user.Professional_Qualification=ProfessionalQualifications_.FindAll(p=>p.Users_Id==user.UserId);
        return user;
      //Users?.FirstOrDefault(p => p.UserId == id);
     }

    public static void Add(User user)
    {
        user.UserId = nextId++;
        Users.Add(user);
       // List<ProfessionalQualification> myAnythingList = (user.Professional_Qualification as IEnumerable<ProfessionalQualification>).Cast<ProfessionalQualification>().ToList();
        //Console.WriteLine(user.Professional_Qualification);
        // ProfessionalQualifications.Add(myAnythingList);
         foreach (var item in user.Professional_Qualification)
       {
           item.ProfessionalQualificationId=nextIdProfessionalQualifications_++;
           item.Users_Id=user.UserId;
           ProfessionalQualifications_.Add(item);
           System.Console.WriteLine( item);
       };
       foreach (var item in user.Educational_Qualification)
       {
           item.EducationalQualificationId=nextIdEducationalQualifications_++;
          item.Users_Id=user.UserId;
           EducationalQualifications_.Add(item);
           //walkin.Roles_id.Append(item.Roles_Id);
           System.Console.WriteLine( item);
       };
       //user.Timeslot=null;
       //user.Role=null;
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

      public static Boolean? IsValidUser(string Email_Id,string Password){
          if(Users.FirstOrDefault(p => p.Email_Id == Email_Id && p.Password==Password)!=null)
          return true;
          else
          return false;
      }

      public static string AddNewApplication(Applications app,int user_id,int walkin_id)
      {
          var check_u_id=Applications_.FirstOrDefault(p=>(p.Walkin_Id==walkin_id && p.Users_Id==user_id));
          System.Console.WriteLine(check_u_id);
          if(check_u_id is not null)
         { return "already applied for this walkin";}
          app.Users_Id=user_id;
          app.Walkin_Id=walkin_id;
          app.Application_Id=nextapp++;
          Applications_.Add(app);
          //return app;
          return " applied successfully";
      }
      public static List<Applications>? GetAllApplicationsDetails()
      {
          System.Console.WriteLine(Applications_);
          
          return Applications_;
      }
      public static List<Applications> GetApplicationOfWalkinId(int id)
      {
          var applications=Applications_.FindAll(p=>p.Walkin_Id==id);
          return applications;
      }
}

