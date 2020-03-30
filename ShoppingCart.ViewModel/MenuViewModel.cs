using ShoppingCart.DBEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.ViewModel
{
    public class MenuViewModels : BaseViewModel
    {
        public IList<MenuViewModel> Menus { get; set; }

        public void PopulateList(IList<Menu> menu)
        {
            if (menu != null && menu.Count > 0)
            {
                Menus = new List<MenuViewModel>();
                var converter = new MenuViewModel();

                Parallel.ForEach(menu, (current) =>
                {
                    Menus.Add(converter.ConvertToViewModel(current));
                });
            }
        }
    }


    public class MenuViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Navigation { get; set; }
        public int Order { get; set; }
        public IList<SubMenuViewModel> SubMenus { get; set; }

        public Menu ConvertToDBEntity(MenuViewModel menu)
        {
            var ret = new Menu()
            {
                Id = menu.Id,
                Navigation = menu.Navigation,
                Name = menu.Name,
                Order = menu.Order,
                IsDeleted = menu.IsDeleted
            };

            if (menu.SubMenus != null && menu.SubMenus.Count > 0)
            {
                ret.SubMenus = new List<SubMenu>();

                Parallel.ForEach(menu.SubMenus, (currentSubMenu) =>
                 { ret.SubMenus.Add(new SubMenuViewModel().ConvertToDBEntity(currentSubMenu)); });
            }

            return ret;
        }

        public MenuViewModel ConvertToViewModel(Menu menu)
        {
            var ret = new MenuViewModel()
            {
                Id = menu.Id,
                Name = menu.Name,
                Order = menu.Order,
                Navigation = menu.Navigation,
                IsDeleted = menu.IsDeleted
            };

            if (menu.SubMenus != null && menu.SubMenus.Count > 0)
            {
                ret.SubMenus = new List<SubMenuViewModel>();

                Parallel.ForEach(menu.SubMenus, (currentSubMenu) =>
                { ret.SubMenus.Add(new SubMenuViewModel().ConvertToViewModel(currentSubMenu)); });
            }

            return ret;
        }
    }

    public class SubMenuViewModel :BaseViewModel
    {
        public long FK_MenuId { get; set; }
        public string Name { get; set; }
        public string Navigation { get; set; }
        public int Order { get; set; }
        
        public SubMenu ConvertToDBEntity(SubMenuViewModel subMenu)
        {
            return new SubMenu()
            {
                Id = subMenu.Id,
                Navigation = subMenu.Navigation,
                Name = subMenu.Name,
                Order = subMenu.Order,
                IsDeleted = subMenu.IsDeleted
            };
        }

        public SubMenuViewModel ConvertToViewModel(SubMenu subMenu)
        {
            return new SubMenuViewModel()
            {
                Id = subMenu.Id,
                Name = subMenu.Name,
                Order = subMenu.Order,
                Navigation = subMenu.Navigation,
                IsDeleted = subMenu.IsDeleted
            };
        }
    }
}
