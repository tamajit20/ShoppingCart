using System.Collections.Generic;
using ShoppingCart.DBEntity;

namespace ShoppingCart.Logic
{
    public interface ICategoryService
    {
        long AddCategory(Category category);
        IList<Category> GetCategories();
    }
}
