using System.Collections.Generic;

namespace ShoppingCart.DBEntity
{
    public class Product : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string PrimaryImage { get; set; }
        public virtual IList<ProductSiteLink> ProductSiteLinks { get; set; } 
        public virtual IList<ProductImage> ProductImages { get; set; }
    }

    public class ProductSiteLink : BaseEntity
    {
        public virtual string Link { get; set; }
        public virtual long FK_ProductId { get; set; }
        public virtual long FK_WebSiteId { get; set; }
        public virtual Website WebSite { get; set; }
    }

    public class ProductImage : BaseEntity
    {
        public virtual string Image { get; set; }
        public virtual long FK_ProductId { get; set; }
        public virtual int Order { get; set; }
    }
}
