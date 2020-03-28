using System.Collections.Generic;

namespace ShoppingCart.DBEntity
{
    public class Menu : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Navigation { get; set; }
        public virtual int Order { get; set; }
        public virtual IList<SubMenu> SubMenus { get; set; }
    }

    public class SubMenu : BaseEntity
    {
        public virtual long FK_MenuId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Navigation { get; set; }
        public virtual int Order { get; set; }
    }
}
