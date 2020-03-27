﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.DBEntity;

namespace ShoppingCart.Logic
{
    public interface IMenuService
    {
        long AddMenu(Menu menu);
        IList<Menu> GetMenus();
    }
}