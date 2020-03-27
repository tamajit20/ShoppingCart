using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.DBEntity;

namespace ShoppingCart.Logic
{
    public interface IProductService
    {
        long AddProduct(Product input);
        IList<Product> GetProducts();
    }
}
