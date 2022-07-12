// See https://aka.ms/new-console-template for more information

namespace newdotnet
{
    class Person
    {
        string name="";
         public void introduce(string a)
         {
             System.Console.WriteLine("Hi {0},I am {1}",a,name);
         }
         public static Person parse(string str){
             var p=new Person();
             p.name=str;
             return p;
         }
    }
}
