using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DBEntity
{
    public class User : BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual long PhoneNumber { get; set; }
        public virtual int PhoneCountryCode { get; set; }
        public virtual string Email { get; set; }
    }
}
