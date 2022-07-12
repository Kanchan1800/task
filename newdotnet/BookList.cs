namespace Generics
{
    public class BookList{
        public void add(Book book){
            throw new NotImplementedException();
        }
        public Book this[int index]{
            get{ throw new NotImplementedException();}
        }
    }

    // public class ObjectList{
    //     public void add(object value){
    //         throw new NotImplementedException();
    //     }
    //     public object this[int index]{
    //         get{ throw new NotImplementedException();}
    //     }
    // }

    public class GenericDictionary<TKey,TValue>
    {
        public void add(TKey key,TValue value)
        {
            
        }
    }
    public class GenericList<T>
    {
        public void add(T value)
        {

        }
        public T this[int index]{
            get{ throw new NotImplementedException();}
        }

    }
    
}