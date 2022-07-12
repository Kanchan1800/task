namespace newdotnet
{
    //where T:IComparable
    //where T:Product
    //where T:struct
    //where T:class
    //where T:new()
    public class Nullable<T> where T:struct{ //this is already there in .net framework !!!
        private object _value;
        public Nullable()
        {
            
        }
        public Nullable(T value)
        {
            _value=value;
        }

        public bool hasValue{
            get{return _value!=null;}
        }
        public T GetValueOrDefault(){
            if (hasValue)
            {
                return (T)_value;
            }
            return default(T);
        }
    }
    
}
