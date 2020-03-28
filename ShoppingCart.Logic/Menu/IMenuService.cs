using System.Collections.Generic;
using ShoppingCart.DBEntity;

namespace ShoppingCart.Logic
{
    public interface IMenuService
    {
        long AddMenu(Menu menu);
        IList<Menu> GetMenus();
    }
}
