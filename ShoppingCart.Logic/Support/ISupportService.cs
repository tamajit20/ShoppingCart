using System.Collections.Generic;
using ShoppingCart.DBEntity;

namespace ShoppingCart.Logic
{
    public interface ISupportService
    {
        long AddContactUs(ContactUs input);
        IList<ContactUsType> GetContactUsTypes();
    }
}
