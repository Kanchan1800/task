namespace newdotnet
{
    public class Utilities { // yaha pe bhi likh sakte hai ki ---------> public class Utilities <T> where T:IComparable
        
        public int maxInt(int a,int b)
        {
            return a>b?a:b;
        }
         public T max<T> (T a, T b) where T:IComparable //yaha where t:icomparable likhna pada becoss otherwise voh t ko object assume karta joh ki apan bada hai ya chota nahi bata pate
         //toh apan ne mention kiya ki t aisa kuch hoga joh comparable implement karega ex:t can be string or int or floator double 

         // upar waise likha toh yaha pe wapis likhne ki jarurat nahi 
         // you can just write --------> public T max (T a, T b)
         {
              return a.CompareTo(b)>0?a:b;
         }

         public void doSomething<T>(T value) where T:new()
         {
             var obj=new T();
         }

    }
    
}
