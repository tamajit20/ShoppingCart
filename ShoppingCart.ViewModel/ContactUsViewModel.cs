using ShoppingCart.DBEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.ViewModel
{
    public class ConactUsTypeViewModels : BaseViewModel
    {
        IList<ContactUsTypeViewModel> ContactUsTypes { get; set; }

        public void PopulateList(IList<ContactUsType> input)
        {
            if (input != null && input.Count > 0)
            {
                ContactUsTypes = new List<ContactUsTypeViewModel>();
                var converter = new ContactUsTypeViewModel();

                Parallel.ForEach(input, (current) =>
                {
                    ContactUsTypes.Add(converter.ConvertToViewModel(current));
                });
            }
        }
    }

    public class ContactUsViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public long Fk_ContactUsType { get; set; }

        public ContactUs ConvertToDBEntity(ContactUsViewModel input)
        {
            var ret = new ContactUs()
            {
                Id = input.Id,
                Name = input.Name,
                Email = input.Email,
                Subject = input.Subject,
                Description = input.Description,
                Fk_ContactUsType = input.Fk_ContactUsType,
                IsDeleted = input.IsDeleted
            };

            return ret;
        }
    }

    public class ContactUsTypeViewModel : BaseViewModel
    {
        public string Type { get; set; }

        public ContactUsTypeViewModel ConvertToViewModel(ContactUsType input)
        {
            var ret = new ContactUsTypeViewModel()
            {
                Id = input.Id,
                Type = input.Type,
                IsDeleted = input.IsDeleted,
            };

            return ret;
        }
    }
}
