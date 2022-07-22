using walkinapi.Models;

namespace walkinapi.Services;

public static class WalkinService
{
    static List<Walkin> Walkins { get; }
     static List<Roles> Role { get;set; }
     static System.Collections.Generic.List<walkinapi.Models.Timeslots> Timeslot{get; set;}
    static int nextId = 3;
    static int nextIdRoles = 5;
    static int nextIdTimeslot = 6;
    static WalkinService()
    {
        Role= new List<Roles>{
            new Roles{Roles_Id=1,Walkin_Id=1,Role_Title="DEV",Description="developer's description",Package="10 LPA"},
            new Roles{Roles_Id=2,Walkin_Id=1,Role_Title="QA",Description="QA's description",Package="6 LPA"},
            new Roles{Roles_Id=3,Walkin_Id=1,Role_Title="DESIGNER",Description="DESIGNER's description",Package="4 LPA"},
            new Roles{Roles_Id=4,Walkin_Id=2,Role_Title="DESIGNER",Description="DESIGNER's description",Package="3.5 LPA"},
        };
        
        Timeslot=new System.Collections.Generic.List<Timeslots>{
            new Timeslots{Timeslots_Id=1,Walkin_Id=1,TimeslotDetail="9:00AM to 11:00AM"},
            new Timeslots{Timeslots_Id=2,Walkin_Id=1,TimeslotDetail="1:00PM to 3:00PM"},
            new Timeslots{Timeslots_Id=3,Walkin_Id=1,TimeslotDetail="4:00PM to 6:00PM"},
            new Timeslots{Timeslots_Id=4,Walkin_Id=2,TimeslotDetail="9:00AM to 12:00AM"},
            new Timeslots{Timeslots_Id=5,Walkin_Id=2,TimeslotDetail="1:00PM to 3:00PM"},
        };

        Walkins = new List<Walkin>
        {
            new Walkin { Id = 1, Title = "Walkin for multiple roles", Duration = "1-Jul-2022 to 14-Jul-2022",Roles=new string []{"DEV","QA","DESIGNER"},Location="Mumbai",
            General_instruc="blah blah blah g ..",Exam_instruc="exam 1",System_req="blah blah blahs ..",ExpiresIn="blah blah blah e..",InternshipDetails="blah blah blah i .." 
            //,Role=Role.FindAll(p=>p.Walkin_Id==1)
            //,Timeslot=Timeslot.FindAll(p=>p.Walkin_Id==1)
            },
             new Walkin { Id = 2, Title = "Walkin for DESIGNER roles", Duration = "5-Jul-2022 to 15-Jul-2022",Roles=new string []{"DESIGNER"},Location="Mumbai",General_instruc="blah blah blah g ..",Exam_instruc="exam 2",System_req="blah blah blahs ..",ExpiresIn="blah blah blah e..",InternshipDetails="blah blah blah i .."
             //,Role=Role.FindAll(p=>p.Walkin_Id==2)
             //,Timeslot=Timeslot.FindAll(p=>p.Walkin_Id==2)
              },
        };
        
    }

    public  static List<Walkin> GetAll() {
       foreach (var item in Walkins)
       {
        item.Timeslot=null;
        item.Role=null;
           
       };
       //System.Console.WriteLine( Walkins[0].Timeslot[0].TimeslotDetail);
       
         return Walkins;
    }


    public static Walkin? Get(int id) 
    {
         var walkin= Walkins.FirstOrDefault(p => p.Id == id);
        walkin.Timeslot=Timeslot.FindAll(p=>p.Walkin_Id==walkin.Id);
        walkin.Role=Role.FindAll(p=>p.Walkin_Id==walkin.Id);
        return walkin;
           
    }
   

    public static void Add(Walkin walkin)
    {
        walkin.Id = nextId++;
        Walkins.Add(walkin);
        //adding new walkins timeslot details into timeslot list 
         foreach (var item in walkin.Timeslot)
       {
           item.Timeslots_Id=nextIdTimeslot++;
           item.Walkin_Id=walkin.Id;
           Timeslot.Add(item);
           //walkin.Timeslot_id.Append(item.Timeslots_Id);
           System.Console.WriteLine( item);
       };
       foreach (var item in walkin.Role)
       {
           item.Roles_Id=nextIdRoles++;
           item.Walkin_Id=walkin.Id;
           Role.Add(item);
           //walkin.Roles_id.Append(item.Roles_Id);
           System.Console.WriteLine( item);
       };
       walkin.Timeslot=null;
       walkin.Role=null;
        System.Console.WriteLine(Role);
    }

    public static void Delete(int id)
    {
        var walkin = Get(id);
        if(walkin is null)
            return;

        Walkins.Remove(walkin);
        var timeslot=Timeslot.FindAll(p=>p.Walkin_Id==walkin.Id);
        foreach (var item in timeslot)
       {
           Timeslot.Remove(item);
       };
       var roles=Role.FindAll(p=>p.Walkin_Id==walkin.Id);
        foreach (var item in roles)
       {
           Role.Remove(item);
       };
        

    }

    public static void Update(Walkin walkin)
    {
        var index = Walkins.FindIndex(p => p.Id == walkin.Id);
        if(index == -1)
            return;

        Walkins[index] = walkin;
    }
      public  static List<Timeslots> GetAllTimeslots() {

       
         return Timeslot;
    }

    public static List<Timeslots> GetAllTimeslotsOfWalkin(int id) 
    {
         var timeslot1= Timeslot.FindAll(p => p.Walkin_Id == id);
        return timeslot1;
           
    }
    public static List<Timeslots> AddTimeslot( Timeslots timeslot,int id)
    {
         timeslot.Timeslots_Id=nextIdTimeslot++;
        timeslot.Walkin_Id=id;
        Timeslot.Add(timeslot);
        return GetAllTimeslotsOfWalkin(id);
           
    }
   
     public  static List<Roles> GetAllRoles() {
         return Role;
    }
    public static List<Roles> GetRolesOfWalkin(int id)
    {
        var roles= Role.FindAll(p=>p.Walkin_Id==id);
        return roles;
    }
     public static List<Roles> AddRolesForWalkinId( Roles roles,int id)
    {
         roles.Roles_Id=nextIdRoles++;
        roles.Walkin_Id=id;
        Role.Add(roles);
        return GetRolesOfWalkin(id);
    }
    
    public static Walkin? IsValid(String title,int id) => Walkins.FirstOrDefault(p => p.Id == id && p.Title==title);
}