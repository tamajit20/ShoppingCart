namespace ShoppingCart.DBEntity
{
    public class BoxComponent : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Image { get; set; }
        public virtual string Link { get; set; }
        public virtual string Text { get; set; }
        public virtual int Order { get; set; }
    }
}
