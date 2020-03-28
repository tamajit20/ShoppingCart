using ShoppingCart.Logic;
using ShoppingCart.ViewModel;
using System;
using System.Web.Http;

namespace ShoppingCart.Web.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IHttpActionResult AddUser(UserViewModel user)
        {
            try
            {
                user.Id = _userService.AddUser(user.ConvertToDBEntity());
                return Ok(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}