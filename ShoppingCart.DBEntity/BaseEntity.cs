using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DBEntity
{
    public class BaseEntity
    {
        public virtual long Id { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string ModifiedBy { get; set; }
    }
}
