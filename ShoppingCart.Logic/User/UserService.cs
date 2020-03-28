using System;
using ShoppingCart.DBEntity;
using ShoppingCart.DBConnect.Common;

namespace ShoppingCart.Logic
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
     
        public long AddUser(User user)
        {
            try
            {
                _userRepository.Add(user);
                return user.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
