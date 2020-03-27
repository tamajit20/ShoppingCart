using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.DBEntity;

namespace ShoppingCart.Logic
{
    public interface IDashboardService
    {
        IList<CarousellComponent> GetCarousellComponents();
        IList<BoxComponent> GetBoxComponents();

    }
}
