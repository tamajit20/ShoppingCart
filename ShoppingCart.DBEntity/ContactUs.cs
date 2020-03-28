namespace ShoppingCart.DBEntity
{
    public class ContactUs : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual long Phone {get;set;}
        public virtual string Subject { get; set; }
        public virtual string Description { get; set; }
        public virtual long Fk_ContactUsType { get; set; }
    }

    public class ContactUsType : BaseEntity
    {
        public virtual string Type { get; set; }
    }
}
