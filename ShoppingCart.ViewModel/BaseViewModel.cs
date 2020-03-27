using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.ViewModel
{
    public class BaseViewModel
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }

    }
}
