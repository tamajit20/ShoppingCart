using System.Collections.Generic;

namespace ShoppingCart.DBEntity
{
    public class Category : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Navigation { get; set; }
        public virtual int Order { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
    }

    public class SubCategory : BaseEntity
    {
        public virtual long FK_CategoryId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Navigation { get; set; }
        public virtual int Order { get; set; }
    }
}
