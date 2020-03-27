namespace ShoppingCart.DBEntity
{
    public class CarousellComponent : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Image { get; set; }
        public virtual string Link { get; set; }
        public virtual int Order { get; set; }
    }
}
