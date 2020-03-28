using ShoppingCart.DBEntity;

namespace ShoppingCart.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public int PhoneCountryCode { get; set; }
        public string Email { get; set; }

        public User ConvertToDBEntity()
        {
            return new User()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                PhoneCountryCode = PhoneCountryCode,
                Email = Email,
                IsDeleted = IsDeleted
            };
        }

        public UserViewModel ConvertToViewModel(User user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PhoneCountryCode = user.PhoneCountryCode,
                Email = user.Email,
                IsDeleted = user.IsDeleted
            };
        }
    }
}