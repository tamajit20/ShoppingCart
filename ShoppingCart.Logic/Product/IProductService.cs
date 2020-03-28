using System.Collections.Generic;
using ShoppingCart.DBEntity;

namespace ShoppingCart.Logic
{
    public interface IProductService
    {
        long AddProduct(Product input);
        IList<Product> GetProducts();
    }
}
