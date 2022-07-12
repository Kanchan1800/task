namespace Generics
{
    public class DiscountCalculator<TProduct> where TProduct:Product
    {
        public float calculateDiscount(TProduct product)
        {
           return product.price;
        }
    }
    
}
