namespace Generics
{
    class Program
    {
        static void main(string[] args){
            // var book=new Book("1111","c# advance");

            // var books= new BookList();
            // books.add(book);

            // var number=new List();
            // number.add(10);

            var numbers= new GenericList<int>();
            numbers.add(10);
            var books =new GenericList<Book>();
            books.add(new Book("1","c# advance"));

            var dict=new GenericDictionary<string,Book>();
            dict.add("first",new Book("1","c# advance"));



        }
    }
    
}// See https://aka.ms/new-console-template for more information

namespace newdotnet
{
    class Program{
        static void Main(string[] args )
        {
            System.Console.WriteLine("Hello world");
            var p=Person.parse("Kanchan");
            p.introduce("John");


            //created generic methodd which can compare int as well as string or any kind of type which can be comparable!!    
            var u = new Utilities();
             var a=u.max<string>("kanchan","arvind");
             System.Console.WriteLine(a);

             var number= new Nullable<int>();
             System.Console.WriteLine(" has value?"+number.hasValue);
             System.Console.WriteLine(" value :" +number.GetValueOrDefault());

        }
    }
}
