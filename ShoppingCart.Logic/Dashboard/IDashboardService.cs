using System.Collections.Generic;
using ShoppingCart.DBEntity;

namespace ShoppingCart.Logic
{
    public interface IDashboardService
    {
        IList<CarousellComponent> GetCarousellComponents();
        IList<BoxComponent> GetBoxComponents();

    }
}
