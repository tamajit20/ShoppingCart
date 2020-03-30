using ShoppingCart.Logic;
using ShoppingCart.ViewModel;
using System;
using System.Web.Http;

namespace ShoppingCart.Web.Controllers
{
    public class MenuController : BaseController
    {
        private IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public IHttpActionResult AddMenu(MenuViewModel menu)
        {
            try
            {
                menu.Id = _menuService.AddMenu(menu.ConvertToDBEntity(menu));
                return Ok(menu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IHttpActionResult FetchMenus()
        {
            MenuViewModels result = new MenuViewModels();
            try
            {
                result.PopulateList(_menuService.GetMenus());
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}