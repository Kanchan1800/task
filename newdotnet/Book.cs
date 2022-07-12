namespace Generics
{
    public class Book:Product
    {
        public string isbn;
        //title ,price product se aa raha hai
        public Book(string isbn,string title)
        {
            this.isbn=isbn;
            this.title=title;
        }
    }
    
}