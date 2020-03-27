using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DBEntity
{
    public class Product : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<ProductSiteLink> ProductSiteLinks { get; set; } 
    }

    public class ProductSiteLink : BaseEntity
    {
        public virtual string Link { get; set; }
        public virtual long FK_ProductId { get; set; }
        public virtual long FK_WebSiteId { get; set; }
        public virtual Website WebSite { get; set; }
    }
}
